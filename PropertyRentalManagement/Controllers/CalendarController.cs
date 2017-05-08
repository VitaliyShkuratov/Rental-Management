using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

using PropertyRentalManagement.Models;
namespace PropertyRentalManagement.Controllers
{
    public class CalendarController : Controller
    {
        public ApplicationDbContext _context;
        public CalendarController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            //Being initialized in that way, scheduler will use CalendarController.Data as a the datasource and CalendarController.Save to process changes
            var scheduler = new DHXScheduler(this);

            /*
             * It's possible to use different actions of the current controller
             *      var scheduler = new DHXScheduler(this);
             *      scheduler.DataAction = "ActionName1";
             *      scheduler.SaveAction = "ActionName2";
             *
             * Or to specify full paths
             *      var scheduler = new DHXScheduler();
             *      scheduler.DataAction = Url.Action("Data", "Calendar");
             *      scheduler.SaveAction = Url.Action("Save", "Calendar");
             */

            /*
             * The default codebase folder is ~/Scripts/dhtmlxScheduler. It can be overriden:
             *      scheduler.Codebase = Url.Content("~/customCodebaseFolder");
             */


            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }

        public ContentResult Data()
        {
            var data = new SchedulerAjaxData(_context.CalendarEvents);

            return (ContentResult)data;
        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = (CalendarEvent)DHXEventsHelper.Bind(typeof(CalendarEvent), actionValues);
                switch (action.Type)
                {
                    // "insert"
                    case DataActionTypes.Insert:
                        _context.CalendarEvents.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        // "delete"
                        _context.CalendarEvents.Remove(_context.CalendarEvents.Find(action.SourceId));
                        break;
                    default:
                        // "update"
                        var calendarEventsInDB = _context.CalendarEvents
                            .Single(e => e.id == action.SourceId);
                        DHXEventsHelper.Update(calendarEventsInDB, changedEvent, new List<string>() { "id" });
                        break;
                }
                _context.SaveChanges();
                action.TargetId = changedEvent.id;
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }
            return (ContentResult)new AjaxSaveResponse(action);
        }

        public ActionResult ChooseDate()
        {

            return View();
        }
    }
}

