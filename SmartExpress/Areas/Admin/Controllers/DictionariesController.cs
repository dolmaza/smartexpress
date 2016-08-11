﻿using Core;
using Core.Properties;
using Core.Utilities;
using SmartExpress.Admin.Models;
using SmartExpress.Admin.Reusable;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SmartExpress.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class DictionariesController : BaseController
    {
        [Route("dictionaries", Name = "Dictionaries")]
        public ActionResult Index()
        {
            var model = new DictionaryViewModel
            {
                DictionariesJson = UnitOfWork.DictionaryRepository.GetAll().ToList().Select(d => new DictionaryObject
                {
                    ID = d.ID,
                    Caption = d.Caption,
                    DictionaryCode = d.DictionaryCode,
                    StringCode = d.StringCode,
                    IntCode = d.IntCode,
                    ParentID = d.ParentID,
                    IsVisible = d.IsVisible,
                    SortVal = d.SortVal
                }).ToJson(),
                DictionaryCreateUrl = Url.RouteUrl("DictionariesCreate")

            };

            return View(model);
        }

        [Route("dictionaries/create", Name = "DictionariesCreate")]
        public ActionResult CreateDictionary(int? parentID)
        {
            var model = new CreateEditDictionaryViewModel
            {
                SaveUrl = Url.RouteUrl("DictionariesCreate"),
                Title = "ზოგადი ცნობარის დამატება",
                DictionaryObject = new DictionaryObject
                {
                    ParentID = parentID ?? 0,
                    ID = 0
                }
            };
            return View("CreateEditDictionary", model);
        }

        [HttpPost]
        [Route("dictionaries/create")]
        public ActionResult CreateDictionary(DictionaryObject model)
        {
            var AR = new AjaxResponse();

            UnitOfWork.DictionaryRepository.Add(new Dictionary
            {
                ParentID = model.ParentID,
                Caption = model.Caption,
                IntCode = model.IntCode,
                StringCode = model.StringCode,
                DictionaryCode = model.DictionaryCode,
                SortVal = model.SortVal,
                IsVisible = model.IsVisible,
                CreateTime = DateTime.Now
            });

            if (UnitOfWork.DictionaryRepository.IsError)
            {
                AR.Data = new
                {
                    Message = Resources.Abort
                };
            }
            else
            {
                AR.IsSuccess = true;
            }

            return Json(AR);
        }

        [Route("dictionaries/{ID}/edit", Name = "DictionariesEdit")]
        public ActionResult EditDictionary(int? ID)
        {
            var dictionary = UnitOfWork.DictionaryRepository.Get(ID);
            if (dictionary == null)
            {
                return NotFound();
            }
            else
            {
                var model = new CreateEditDictionaryViewModel
                {
                    SaveUrl = Url.RouteUrl("DictionariesEdit", new { ID = ID }),
                    Title = "ზოგადი ცნობარის რედაქტირება",
                    DictionaryObject = new DictionaryObject
                    {
                        ID = dictionary.ID,
                        Caption = dictionary.Caption,
                        DictionaryCode = dictionary.DictionaryCode,
                        IntCode = dictionary.IntCode,
                        StringCode = dictionary.StringCode,
                        ParentID = dictionary.ParentID,
                        IsVisible = dictionary.IsVisible,
                        SortVal = dictionary.SortVal
                    }
                };

                return View("CreateEditDictionary", model);
            }
        }
    }
}