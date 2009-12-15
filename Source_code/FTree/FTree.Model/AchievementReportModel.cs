using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using System.Data.Linq;
using System.Collections;

namespace FTree.Model
{
    public class AchievementReportModel : BaseModel, IAchievementReportModel
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
       
        #endregion

        #region CONSTRUCTOR
        
        public AchievementReportModel()
            : base()
        {
        }

        public AchievementReportModel(FTreeDataContext sharedDataContext)
            : base(sharedDataContext)
        {
        }

        #endregion

        #region ULTILITY METHOD


        private MEMBER_EVENT _convertFromDTO (AchievementReportDTO arDTO)
        {
            MEMBER_EVENT achivement = new MEMBER_EVENT();

            //achivement.IDAchievement = arDTO.ID;
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
        /// core method for update row to Datagridview
        /// </summary>
        /// <returns></returns>
        public List<AchievementReportDTO> AchievementReport(int fromYear, int toYear)
        {
            
            FTreeDataContext ftree = new FTreeDataContext();
            Table<MEMBER_EVENT> mee = ftree.GetTable<MEMBER_EVENT>();
            Table<EVENT> eve = ftree.GetTable<EVENT>();

            
            var matches1 = from me in mee
                           join e in eve on me.EVENT.IDEvent equals e.IDEvent
                           where (me.EventDate.GetValueOrDefault().Year <= toYear &&
                            me.EventDate.GetValueOrDefault().Year >= fromYear
                            ) 
                           group me by me.EVENT.Name into g
                           select new { Name = g.Key, Num = g.Count() };

            List<AchievementReportDTO> list_arDTO = new List<AchievementReportDTO>();
            
            foreach (var achive in matches1)
            {
                AchievementReportDTO arDTO = new AchievementReportDTO();
                arDTO.AchievementName = achive.Name;
                arDTO.Total = achive.Num;
                list_arDTO.Add(arDTO);
            }
            return list_arDTO;            
        }
        #endregion
        
        #region IModel<AchievementReportDTO> Members


        public void Update(AchievementReportDTO obj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IAchievementReportModel Members

        string IAchievementReportModel.AddWithString()
        {
            throw new NotImplementedException();
        }

        List<MEMBER_EVENT> IAchievementReportModel.Add()
        {
            throw new NotImplementedException();
        }

        Array IAchievementReportModel.AddWithArray()
        {
            throw new NotImplementedException();
        }

        List<AchievementReportDTO> IAchievementReportModel.AchievementReport(int from, int to)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILinqModel<AchievementReportDTO> Members

        IEnumerable<AchievementReportDTO> MVPCore.ILinqModel<AchievementReportDTO>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IModel<AchievementReportDTO> Members

        IList<AchievementReportDTO> MVPCore.IModel<AchievementReportDTO>.GetAll()
        {
            throw new NotImplementedException();
        }

        AchievementReportDTO MVPCore.IModel<AchievementReportDTO>.GetOne(int id)
        {
            throw new NotImplementedException();
        }

        void MVPCore.IModel<AchievementReportDTO>.Add(AchievementReportDTO obj)
        {
            throw new NotImplementedException();
        }

        void MVPCore.IModel<AchievementReportDTO>.Delete(AchievementReportDTO obj)
        {
            throw new NotImplementedException();
        }

        void MVPCore.IModel<AchievementReportDTO>.Update(AchievementReportDTO obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
