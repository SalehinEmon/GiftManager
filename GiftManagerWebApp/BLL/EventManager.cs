using GiftManagerWebApp.DatabaseContext;
using GiftManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiftManagerWebApp.BLL
{
    public class EventManager
    {
        private GiftManagerContext _giftManagerContext;
        public EventManager() { _giftManagerContext = new GiftManagerContext(); }

        public EventModel GetEventById(int id)
        {
            EventModel eventModel = null;

            eventModel = _giftManagerContext
                        .EventModels
                        .Where(e => e.Id == id).FirstOrDefault();

            return eventModel;

        }

        public int AddEvent(EventModel eventModel)
        {
            _giftManagerContext.EventModels.Add(eventModel);
            int rowEffected = _giftManagerContext.SaveChanges();

            return rowEffected;
        }

        public List<EventModel> GetAllEventModel()
        {
            List<EventModel> allEventmodel = _giftManagerContext.EventModels.ToList();


            return allEventmodel;
        }

        public List<SelectListItem> GetAllEventModelForDropdown()
        {
            List<SelectListItem> allEventModel = new List<SelectListItem>();

            foreach (EventModel eventModel in GetAllEventModel())
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Text = eventModel.EventName;
                selectListItem.Value = eventModel.Id.ToString();

                allEventModel.Add(selectListItem);
            }



            return allEventModel;
        }

        
    }
}