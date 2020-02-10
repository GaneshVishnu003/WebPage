using System;
using OnlineCabBooking.DAL;
using OnlineCabBooking.Entity;

namespace OnlineCabBooking.BL
{
    public class CustomerBL
    {
        public static void DeleteRow(int id)
        {
            CustomerDAL.DeleteRow(id);
        }
        public static void UpdateRow(string location,int id)
        {
            CustomerDAL.UpdateRow(location,id);
        }
        public static void InsertRow(string location)
        {
            CustomerDAL.InsertRow(location);
        }
    }
}
