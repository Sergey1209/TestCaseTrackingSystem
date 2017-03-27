﻿using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DataAccess;
using DataAccess.Repositories.Implementation;
using Services.DTO;
using Services.Implementation;
using Services.Interfaces;
using TestCaseStorage.Models.Iterations;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class IterationsController : Controller
    {
        private IIterationService IterationsService { get; }

        public IterationsController()
        {
            IterationsService = new IterationDbService(new TCTSUnitOfWork(new TCTSDataContext()));
        }

        [HttpGet]
        public ViewResult List()
        {
            var iterationsListModel = Mapper.Map<IEnumerable<IterationViewModel>>(IterationsService.GetAllIterations());

            return View("List", iterationsListModel);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View("Edit");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var iterationModel = Mapper.Map<IterationViewModel>(IterationsService.GetIterationById(id));

            return View("Edit", iterationModel);
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int id)
        {
            IterationsService.DeleteIteration(id);

            return RedirectToAction("List");
        }

        [HttpPost]
        public RedirectToRouteResult Save(IterationViewModel iteration)
        {
            if (iteration.IsNew)
            {
                IterationsService.AddNew(Mapper.Map<IterationDto>(iteration));
            }
            else
            {
                IterationsService.Update(Mapper.Map<IterationDto>(iteration));
            }

            return RedirectToAction("List");
        }
    }
}