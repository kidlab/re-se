using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using System.Data.Linq;
using System.Collections;

namespace FTree.Model
{
    public class AchievementReportModel : IAchievementReportModel
    {

        #region ILinqModel<AchievementReportDTO> Members

        public IEnumerable<FTree.DTO.AchievementReportDTO> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IModel<AchievementReportDTO> Members

        public IList<FTree.DTO.AchievementReportDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public FTree.DTO.AchievementReportDTO GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(FTree.DTO.AchievementReportDTO obj)
        {
            FTreeDataContext ftree = new FTreeDataContext();
            Table<MEMBER_EVENT> me = ftree.GetTable<MEMBER_EVENT>();

            var matches = from entity in me 
                          select entity;
            
            string sqlQuery = matches.ToString();    
        
        }

        
        
        public void Delete(FTree.DTO.AchievementReportDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        #endregion

        
        #region VARIABLE
        FTreeDataContext db = new FTreeDataContext();

        #endregion

        #region CONSTRUCTOR
        public AchievementReportModel()
        {
        }

        #endregion

        #region ULTILITY METHOD


        private MEMBER_EVENT _convertFromDTO (AchievementReportDTO arDTO)
        {
            MEMBER_EVENT achivement = new MEMBER_EVENT();

            achivement.IDAchievement = arDTO.ID;
            //achivement. = arDTO.

            return achivement;
        }

        #endregion


        #region IAchievementReportModel Members

        public string AddWithString()
        {
            FTreeDataContext ftree = new FTreeDataContext();
            Table<MEMBER_EVENT> me = ftree.GetTable<MEMBER_EVENT>();

            var matches = from entity in me
                          select entity;
            List<MEMBER_EVENT> lmem_event = matches.ToList();
            
            string que  = lmem_event.ToString();
            Array query = matches.ToArray();

            return que;

        }

        public List<MEMBER_EVENT> Add()
        {
            FTreeDataContext ftree = new FTreeDataContext();
            Table<MEMBER_EVENT> me = ftree.GetTable<MEMBER_EVENT>();

            var matches = from entity in me
                          select entity;


            List<MEMBER_EVENT> lmem_event = matches.ToList();
                       

            return lmem_event;
        }
        
        public Array AddWithArray()
        {
            
            FTreeDataContext ftree = new FTreeDataContext();
            Table<MEMBER_EVENT> me = ftree.GetTable<MEMBER_EVENT>();

            var matches = from entity in me
                          select entity;
            List<MEMBER_EVENT> lmem_event = matches.ToList();

            string que = lmem_event.ToString();
            Array query = matches.ToArray();

            return query;

        }
        /// <summary>
        /// !!phat need to do
        /// </summary>
        /// <returns></returns>
        public List<MEMBER_EVENT> AchievementReport()
        {
            FTreeDataContext ftree = new FTreeDataContext();
            Table<MEMBER_EVENT> me = ftree.GetTable<MEMBER_EVENT>();

            //var matches = from entity in me
            //              select entity;
            //SELECT idevent, COUNT(idmember) AS Total
            //FROM member_event 
            //where (YEAR(achievementdate) < Todate.int) AND (YEAR(achievementdate) >20)
            //GROUP BY idevent
            var matches = from o in me
                          //where o.AchievementDate
                          group o by o.IDAchievement into g
                          select new
                          {
                              Achievement = g.Key,
                              Total = g.Count()
                              };
            //***
            //1.xac dinh ham linq cho Year(date)
            //2.Tim IEnumerable<IGrouping<,>> để show cho DataGridView

            //IEnumerable<IGrouping<Int32,>> lmem_event = matches.ToList();
            //var lmem_event = matches.ToList();

            return null;
            //return lmem_event;
        }
        #endregion

       

       

      
    }
}
