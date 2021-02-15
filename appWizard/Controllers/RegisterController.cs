using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appWizard.Models;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
using DNTCaptcha.Core;
using Microsoft.Extensions.Options;

namespace appWizard.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationContext _context;
        private IMemoryCache _cache;
        private readonly IMapper _mapper;

        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;

        public RegisterController(ApplicationContext context, IMemoryCache memoryCache, IMapper mapper,
            IDNTCaptchaValidatorService validatorService, IOptions<DNTCaptchaOptions> options)
        {
            _context = context;
            _cache = memoryCache;
            _mapper = mapper;
            _validatorService = validatorService;
            _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;
        }    
        


        public async Task<IActionResult> Index()
        {
            var model = new Model { Id = Guid.NewGuid().ToString() };
            model.StepViewOne = new StepViewOne { ModelId = model.Id };
            model.StepViewTwo = new StepViewTwo { ModelId = model.Id };
            model.StepViewThree = new StepViewThree { ModelId = model.Id };
            model.StepViewFour = new StepViewFour { ModelId = model.Id };

            _cache.Set(model.Id, model);
            return RedirectToAction(nameof(Create), new { modelId = model.Id});
        }



        public IActionResult Create(string modelId)
        {
            if (modelId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var modelCache = _cache.Get(modelId);

            if (modelCache == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = (Model)modelCache;

            ViewData["Salutation"] = new List<SelectListItem> { 
                new SelectListItem { Text = "Dear Mr.", Value = "Dear Mr."},
                new SelectListItem { Text = "Dear Mrs.", Value = "Dear Mrs."},
                new SelectListItem { Text = "Dear Ms.", Value = "Dear Ms."},
                new SelectListItem { Text = "Dear Sir.", Value = "Dear Sir."},
                new SelectListItem { Text = "Dear Madam.", Value = "Dear Madam."},
            };
            return View(model.StepViewOne);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StepViewOne stepViewOne)
        {
            if (!ModelState.IsValid)
            {
                return View(stepViewOne);
            }

            var modelCache = (Model)_cache.Get(stepViewOne.ModelId);
            modelCache.StepViewOne = stepViewOne;
            return RedirectToAction(nameof(ViewStepTwo), new { modelId = modelCache.Id });             
        }



        public IActionResult ViewStepTwo(string modelId)
        {
            if (modelId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var modelCache = _cache.Get(modelId);

            if (modelCache == null)
            {
                return RedirectToAction(nameof(Index)); 
            }

            var model = (Model)modelCache;
            return View(model.StepViewTwo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewStepTwo(StepViewTwo stepViewTwo)
        {
            if (!ModelState.IsValid)
            {
                return View(stepViewTwo);
            }

            if (stepViewTwo.Finance == true || stepViewTwo.Administrative == true || stepViewTwo.IT == true || stepViewTwo.Legal == true || stepViewTwo.Marketing == true || stepViewTwo.Operations == true || stepViewTwo.Sales == true)
            {            }
            else
            {
                ViewData["CheckedInfo"] = "Please select your personal business area.";
                return View(stepViewTwo);
            }

            var model = (Model)_cache.Get(stepViewTwo.ModelId);
            model.StepViewTwo = stepViewTwo;
            return RedirectToAction(nameof(ViewStepThree), new { modelId = model.Id });
        }



        public IActionResult ViewStepThree(string modelId)
        {
            if (modelId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var modelCache = _cache.Get(modelId);

            if (modelCache == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            var model = (Model)modelCache;
            return View(model.StepViewThree);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewStepThree(StepViewThree stepViewThree)
        {
            if (!ModelState.IsValid)
            {
                return View(stepViewThree);
            }

            var model = (Model)_cache.Get(stepViewThree.ModelId);
            model.StepViewThree = stepViewThree;
            return RedirectToAction(nameof(ViewStepFour), new { modelId = model.Id });
        }



        public IActionResult ViewStepFour(string modelId)
        {
            if (modelId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var modelCache = _cache.Get(modelId);

            if (modelCache == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            var model = (Model)modelCache;
            return View(model.StepViewFour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewStepFour(StepViewFour stepViewFour)
        {
            if (!_validatorService.HasRequestValidCaptchaEntry(Language.English, DisplayMode.SumOfTwoNumbers))
            {
                this.ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Please enter the security code as a number.");
                return View(stepViewFour);
            }

            if (!ModelState.IsValid)
            {
                return View(stepViewFour);
            }

            var model = (Model)_cache.Get(stepViewFour.ModelId);
            model.StepViewFour = stepViewFour;
            return RedirectToAction(nameof(ViewFinal), new { modelId = model.Id });
        }



        public IActionResult ViewFinal(string modelId)
        {
            if (modelId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var modelCache = _cache.Get(modelId);
            if (modelCache == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = (Model)modelCache;  
            var registerModelUser = _mapper.Map<RegisterModelUser>(model);

            if(registerModelUser.Salutation == null||registerModelUser.Comments == null || registerModelUser.Address == null || registerModelUser.Password == null)
            {
                return RedirectToAction(nameof(Create));
            }

            _context.Add(registerModelUser);
            _context.SaveChangesAsync();
            _cache.Remove(modelId);
            return View();
        }



        private bool RegisterModelUserExists(int id)
        {
            return _context.RegisterModelUsers.Any(e => e.Id == id);
        }
    }
}
