using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using System.Data.Linq;
using System.Collections;

namespace FTree.Model
{
    public class FamilyReportModel : IFamilyReportModel
    {
        #region ILinqModel<FamilyReportDTO> Members

        public IEnumerable<FTree.DTO.FamilyReportDTO> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IModel<FamilyReportDTO> Members

        public IList<FTree.DTO.FamilyReportDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public FTree.DTO.FamilyReportDTO GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(FTree.DTO.FamilyReportDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(FTree.DTO.FamilyReportDTO obj)
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
        public FamilyReportModel()
        {
        }

        #endregion

        #region CORE METHOD
        public List<FamilyReportDTO> FamilyReport(int fromYear, int toYear)
        {

            FTreeDataContext ftree = new FTreeDataContext();
            Table<MEMBER> member = ftree.GetTable<MEMBER>();
            Table<DEATH_INFO> death = ftree.GetTable<DEATH_INFO>();
            Table<RELATIONSHIP> relation = ftree.GetTable<RELATIONSHIP>();



            var matches1 = from m in member
                           //join e in death on m.DEATH_INFO.IDMember equals e.IDMember
                           //join f in relation on m.IDMember equals f.MEMBER1.IDMember
                           where (m.Birthday.GetValueOrDefault().Year <= toYear &&
                            m.Birthday.GetValueOrDefault().Year >= fromYear
                            )
                           select new { m.IDMember };
                           //group me by me.EVENT.Name into g
                           //select new { Name = g.Key, Num = g.Count() };

            List<FamilyReportDTO> list_frDTO = new List<FamilyReportDTO>();

            foreach (var achive in matches1)
            {
                FamilyReportDTO frDTO = new FamilyReportDTO();
                //frDTO.Year = achive.Name;
                //frDTO = achive.Num;
                list_frDTO.Add(frDTO);
            }
            return list_frDTO;
        }

        #endregion
    }
}
