using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using System.Data.Linq;
using System.Collections;

namespace FTree.Model
{
    public class freportStruct {
        public int year { get; set; }
        public int total {get;set;}
    }
    public class FamilyReportModel : BaseModel, IFamilyReportModel
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

        public void Update(FamilyReportDTO obj)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region VARIABLE
        
        #endregion

        #region CONSTRUCTOR
        public FamilyReportModel()
            : base()
        {
        }

        public FamilyReportModel(FTreeDataContext sharedDataContext)
            : base(sharedDataContext)
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
                           where (m.Birthday.GetValueOrDefault().Year <= toYear &&
                            m.Birthday.GetValueOrDefault().Year >= fromYear
                            )
                           group m by m.Birthday.GetValueOrDefault().Year into bornMemberByYear
                           select new
                           {
                               Year = bornMemberByYear.Key,
                               TotalBorn = bornMemberByYear.Count()
                           };
            var matches2 = from m in death
                           where (m.BuryDay.GetValueOrDefault().Year <= toYear &&
                            m.BuryDay.GetValueOrDefault().Year >= fromYear
                            )
                           group m by m.BuryDay.GetValueOrDefault().Year into dieMemberByYear
                           select new
                           {
                               Year = dieMemberByYear.Key,
                               TotalDead = dieMemberByYear.Count()
                           };
            var matches3 = from m in relation
                           where (m.MarriedDate.GetValueOrDefault().Year <= toYear &&
                            m.MarriedDate.GetValueOrDefault().Year >= fromYear
                            )
                           group m by m.MarriedDate.GetValueOrDefault().Year into MemberByYear
                           select new
                           {
                               Year = MemberByYear.Key,
                               TotalMarried = MemberByYear.Count()
                           };

            //var match = from m1 in matches1
            //            join m2 in matches2 on m1.Year equals m2.Year
            //            join m3 in matches3 on m2.Year equals m3.Year
            //            into familyreport
            //            from fr in familyreport.DefaultIfEmpty()
            //            select new
            //            {
            //                Year = m1.Year,
            //                TotalBorn = m1 == null ? (decimal?) null : m1.TotalBorn,
            //                TotalDead = m2 == null ? (decimal?) null : m2.TotalDead,
            //                TotalMarried = fr == null ? (decimal?)null : fr.TotalMarried
            //            };            

            var match6 = from m1 in matches1
                        join m2 in matches2 on m1.Year equals m2.Year                        
                        into familyreport
                        from fr in familyreport.DefaultIfEmpty()
                        select new
                        {
                            Year = m1.Year,
                            TotalBorn = m1 == null ? (decimal?)null : m1.TotalBorn,
                            TotalDead = fr == null ? (decimal?)null : fr.TotalDead,                            
                        };
            var match7 = from m2 in matches2
                         join m1 in matches1 on m2.Year equals m1.Year
                         into familyreport
                         from fr in familyreport.DefaultIfEmpty()
                         select new
                         {
                             Year = fr.Year,
                             TotalBorn = fr == null ? (decimal?)null : fr.TotalBorn,
                             TotalDead = fr == null ? (decimal?)null : m2.TotalDead,
                         };
            var match8 = match6.Union(match7);
            var match9 = from m8 in match8
                         join m3 in matches3 on m8.Year equals m3.Year
                        into familyreport
                         from fr in familyreport.DefaultIfEmpty()
                         select new
                         {
                             Year = m8.Year,
                             TotalBorn = m8 == null ? (decimal?)null : m8.TotalBorn,
                             TotalDead = m8 == null ? (decimal?)null : m8.TotalDead,
                             TotalMarried = fr == null ? (decimal?)null : fr.TotalMarried
                         };
            var match10 = from m3 in matches3
                         join m8 in match8 on m3.Year equals m8.Year
                        into familyreport
                         from fr in familyreport.DefaultIfEmpty()
                         select new
                         {
                             Year = fr.Year,
                             TotalBorn = fr == null ? (decimal?)null : fr.TotalBorn,
                             TotalDead = fr == null ? (decimal?)null : fr.TotalDead,
                             TotalMarried = m3 == null ? (decimal?)null : m3.TotalMarried
                         };
            var match11 = match10.Union(match9);
                        
            List<FamilyReportDTO> list_frDTO = new List<FamilyReportDTO>();

            foreach (var achive in match11)
            {
                FamilyReportDTO frDTO = new FamilyReportDTO();
                frDTO.Year = achive.Year;
                frDTO.BirthQuantity = (achive.TotalBorn == null) ? 0 : (int)achive.TotalBorn;
                frDTO.DeathQuantity = (achive.TotalDead == null) ? 0 : (int)achive.TotalDead;
                frDTO.MarriageQuantity = (achive.TotalMarried == null) ? 0 : (int) achive.TotalMarried;
                list_frDTO.Add(frDTO);
            }
            return list_frDTO;
        }

        #endregion
    }
}
