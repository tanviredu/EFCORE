using System;
using Samurai.Data;
using Samurai.Data.BasicCrud;
using Samurai.Data.Related_data_Crud;

namespace Samurai.Execution
{
    class Program
    {
        static void Main(string[] args)
        {
            //var cr = new CrudRepository();
            //cr.AddSamurai();
            //cr.GetSamuraies();
            //cr.insertVariousTypes();
            //cr.MyFirstOrDefault();
            //cr.addBattle();
            //cr.Disconnectedupdate();
            var cr = new RelatedCrud();
            //cr.AddHorse();
            //cr.addRelatedData();
            //cr.addDataDisconnectedSenario();
            cr.GetHorseWithSamurai();
        }
    }
}

