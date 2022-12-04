using Business.Abstarct;
using DataAccess.Abstarct;
using Entities.Entity;
using GuideTree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GuideTree.Controllers
{
    public class GuideTreeController:Controller
    {
        private readonly ILogger<GuideTreeController> _logger;
        private ISoftwareLangueService _langueService;
        private ISoftwareBranchDal _branchRepository;
        public GuideTreeController(ILogger<GuideTreeController> logger, ISoftwareLangueService langueService, ISoftwareBranchDal branchRepository)
        {
            _logger = logger;
            _langueService= langueService;
            _branchRepository= branchRepository;    
        }

        public IActionResult DesignGuide()
        {
            return View();
        }
        public IActionResult ProgrammerGuide()
        {
            var model = new SoftwareLangueListViewModel()
            {
                softwareBranchs = _branchRepository.GetAll(),
                softwareLangues = _langueService.GetAll(),
            };
            return View(model);
        }
        public IActionResult LangueDetails(string langueurl)
        {
            if (langueurl == null)
            {
                NotFound();
            }
            SoftwareLangue softwareLangue = _langueService.GetLangueDetails(langueurl);
            if(softwareLangue==null)
            {
                NotFound();
            }

            return View(new SoftwareLangueDetailModel()
            {
                softwareLangue=softwareLangue,
            });
        }
    }
}
