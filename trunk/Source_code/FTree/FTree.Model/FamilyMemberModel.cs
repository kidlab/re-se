using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FTree.DTO;

namespace FTree.Model
{
    public class FamilyMemberModel : IFamilyMemberModel
    {
        #region VARIABLES

        FTreeDataContext db = new FTreeDataContext();

        #endregion

        #region CONSTRUCTOR

        public FamilyMemberModel()
        {

        }

        #endregion

        #region ILinqModel<FamilyMemberDTO> Members

        public IEnumerable<FamilyMemberDTO> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IModel<FamilyMemberDTO> Members

        public IList<FamilyMemberDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public FamilyMemberDTO GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(FamilyMemberDTO obj)
        {
            try
            {
                //db.FamilyMember_Tests.InsertOnSubmit(_convertFromDTO(obj));
                db.SubmitChanges();
            }
            catch (Exception exc)
            {
                throw new FTreeDbAccessException();
            }
        }

        public void Delete(FamilyMemberDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        #endregion
        
        #region UTILITY METHODS

        //private FamilyMember_Test _convertFromDTO(FamilyMemberDTO memberDto)
        //{
        //    //FamilyMember_Test member = new FamilyMember_Test();

        //    member.FirstName = memberDto.FirstName;
        //    member.LastName = memberDto.LastName;
        //    member.Gender = memberDto.IsFemale ? (byte)1 : (byte)0;
        //    member.Address = memberDto.Address;
        //    member.HomeTown = memberDto.HomeTown.Name;
        //    member.BirthDay = memberDto.BirthDay;
        //    member.DayJoinFamily = memberDto.DateJoinFamily;
        //    member.Career = memberDto.Career.Name;

        //    return member;
        //}

        #endregion
    }
}
