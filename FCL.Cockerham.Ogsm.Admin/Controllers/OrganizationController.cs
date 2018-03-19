using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using FCL.Cockerham.Ogsm.Admin.Core;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;
using System.IO;

namespace FCL.Cockerham.Ogsm.Admin.Controllers
{
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrganizationController : ViewControllerBase
    {
        [Import]
        IUnitOfWork _dataRepositoryFactory { get; set; }

        [Import]
        IOrganizationService _organizationDomainService { get; set; }

        [Import]
        ILoggerService _logger { get; set; }

        [Import]
        IEncryption _encryptor { get; set; }

        [Import]
        IGeneralFunctions _generalFunctions { get; set; }

        [Import]
        INullHandler _nullHandler { get; set; }

        [Import]
        IConfigCaller _configCaller { get; set; }

        [Import]
        IEmailSender _emailSender { get; set; }

        [Import]
        ICountryService _countryService { get; set; }


        [Import]
        IStateService _stateService { get; set; }

        // GET: Organization
        public ActionResult Index()
        {
            ICollection<OrganizationDto> _organizations = _organizationDomainService.GetAllOrganizations(_dataRepositoryFactory);
            return View(_organizations);
        }

        [HttpGet]
        public PartialViewResult filter4Organization(string orgName)
        {
            return PartialView("_ListOrganizationTable", GetFilteredOrganizationList(orgName));
        }

        private IEnumerable<OrganizationDto> GetFilteredOrganizationList(string _orgName)
        {
            IEnumerable<OrganizationDto> ret = null;

            try
            {
                if (string.IsNullOrEmpty(_orgName))
                {
                    ret = _organizationDomainService.GetAllOrganizations(_dataRepositoryFactory);
                }
                else
                {
                    ret = _organizationDomainService.GetFilteredOrganizationListByOrgName(_orgName, _dataRepositoryFactory);
                }
            }
            catch
            {
                return null;
            }

            return ret;
        }

        [HttpGet]
        public PartialViewResult FilterReset()
        {
            ICollection<OrganizationDto> _orgs = _organizationDomainService.GetAllOrganizations(_dataRepositoryFactory);
            return PartialView("_ListOrganizationTable", _orgs);
        }

        // GET: Organization/Details/5
        public ActionResult Details(int id)
        {
            OrganizationDto organization = _organizationDomainService.GetOrganizationByOrganizationId(id, _dataRepositoryFactory);

            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            //ViewBag.CountryId = new SelectList(_countryService.GetAllCountries(_dataRepositoryFactory), "CountryId", "Name");
            //ViewBag.OrganizationTypeId = new SelectList(_orgTypeService.GetAllOrganizationTypes(_dataRepositoryFactory), "OrganizationTypeId", "Name");
            //ViewBag.StateId = new SelectList(_stateService.GetAllStates(_dataRepositoryFactory), "StateId", "StateName");
            return View();
        }

        // POST: Organization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationId,Name,AddressOne,AddressTwo,City,State,Zip,Phone,Logo,IsActive")] OrganizationDto organization)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Organizations.Add(organization);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.CountryId = new SelectList(_countryService.GetAllCountries(_dataRepositoryFactory), "CountryId", "Name");
            //ViewBag.OrganizationTypeId = new SelectList(_orgTypeService.GetAllOrganizationTypes(_dataRepositoryFactory), "OrganizationTypeId", "Name");
            //ViewBag.StateId = new SelectList(_stateService.GetAllStates(_dataRepositoryFactory), "StateId", "StateName");

            try
            {
                if (ModelState.IsValid)
                {
                    LoggedInUserDto user = (LoggedInUserDto)Session["LoggedInUser"];

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = DateTime.Now.Ticks + "-" + Path.GetFileName(file.FileName);
                            organization.Logo = fileName;
                            string extension = Path.GetExtension(fileName);

                            var path = Path.Combine(Server.MapPath("~/Uploads/Logo/"), fileName);
                            file.SaveAs(path);
                        }
                    }

                    organization.CreatedBy = user.UserId;
                    organization.CreatedDate = DateTime.Now;
                    organization.UpdatedBy = null;
                    organization.UpdatedDate = null;

                    _organizationDomainService.CreateOrganization(organization, _dataRepositoryFactory);
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return View(organization);
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
            OrganizationDto organization = _organizationDomainService.GetOrganizationByOrganizationId(id, _dataRepositoryFactory);

            //ViewBag.CountryId = new SelectList(_countryService.GetAllCountries(_dataRepositoryFactory), "CountryId", "Name", organization.CountryId);
            //ViewBag.OrganizationTypeId = new SelectList(_orgTypeService.GetAllOrganizationTypes(_dataRepositoryFactory), "OrganizationTypeId", "Name", organization.OrganizationTypeId);
            //ViewBag.StateId = new SelectList(_stateService.GetAllStates(_dataRepositoryFactory), "StateId", "StateName", organization.State);

            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationId,Name,AddressOne,AddressTwo,City,State,Zip,Phone,Logo,IsActive")] OrganizationDto organization)
        {
            //ViewBag.CountryId = new SelectList(_countryService.GetAllCountries(_dataRepositoryFactory), "CountryId", "Name", organization.CountryId);
            //ViewBag.OrganizationTypeId = new SelectList(_orgTypeService.GetAllOrganizationTypes(_dataRepositoryFactory), "OrganizationTypeId", "Name", organization.OrganizationTypeId);
            //ViewBag.StateId = new SelectList(_stateService.GetAllStates(_dataRepositoryFactory), "StateId", "StateName", organization.State);
            try
            {
                if (ModelState.IsValid)
                {
                    LoggedInUserDto user = (LoggedInUserDto)Session["LoggedInUser"];
                    OrganizationDto updatingOrganization = _organizationDomainService.GetOrganizationByOrganizationId(organization.OrganizationId, _dataRepositoryFactory);

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = DateTime.Now.Ticks + "-" + Path.GetFileName(file.FileName);
                            updatingOrganization.Logo = fileName;
                            string extension = Path.GetExtension(fileName);

                            var path = Path.Combine(Server.MapPath("~/Uploads/Logo/"), fileName);
                            file.SaveAs(path);
                        }
                    }

                    updatingOrganization.Name = organization.Name;
                    updatingOrganization.AddressOne = organization.AddressOne;
                    updatingOrganization.AddressTwo = organization.AddressTwo;
                    updatingOrganization.City = organization.City;
                    updatingOrganization.State = organization.State;
                    updatingOrganization.Zip = organization.Zip;
                    updatingOrganization.Phone = organization.Phone;
                    updatingOrganization.IsActive = organization.IsActive;
                    updatingOrganization.UpdatedBy = user.UserId;
                    updatingOrganization.UpdatedDate = DateTime.Now;
                    _organizationDomainService.UpdateOrganization(updatingOrganization, organization.OrganizationId, _dataRepositoryFactory);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return View(organization);
        }

        // GET: Organization/Delete/5
        public ActionResult Delete(int id)
        {
            OrganizationDto organization = _organizationDomainService.GetOrganizationByOrganizationId(id, _dataRepositoryFactory);

            if (organization == null)
            {
                return HttpNotFound();
            }

            return View(organization);
        }

        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _organizationDomainService.DeleteOrganization(id, _dataRepositoryFactory);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
