using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTree.DTO;
using FTree.Common;

namespace FTree.Model
{
    public class JobModel : BaseModel, IJobModel
    {
        #region VARIABLES

        
        #endregion

        #region CONSTRUCTOR

        public JobModel()
            : base()
        {
        }

        public JobModel(FTreeDataContext sharedDataContext)
            : base(sharedDataContext)
        {

        }

        #endregion

        #region ILinqModel<JobDTO> Members

        public IEnumerable<FTree.DTO.JobDTO> GetEnumerator()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<JobDTO> matches =
                    _db.JOBs.Select(job => ConvertToDTO(job));
                return matches;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(JobModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region IModel<JobDTO> Members

        public IList<FTree.DTO.JobDTO> GetAll()
        {
            try
            {
                _refreshDataContext();
                IEnumerable<JobDTO> matches =
                    _db.JOBs.Select(job => ConvertToDTO(job));
                return matches.ToList();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(JobModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public FTree.DTO.JobDTO GetOne(int id)
        {
            try
            {
                _refreshDataContext();
                JOB jobMapper =
                    _db.JOBs.SingleOrDefault(job => job.IDJob == id);
                return ConvertToDTO(jobMapper);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(JobModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Add(FTree.DTO.JobDTO obj)
        {
            try
            {
                JOB job = ConvertToMapper(obj);
                _db.JOBs.InsertOnSubmit(job);
                this._save();
                obj.ID = job.IDJob;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(JobModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        public void Delete(FTree.DTO.JobDTO obj)
        {
            try
            {
                _db.JOBs.DeleteOnSubmit(ConvertToMapper(obj));
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(JobModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }
        
        public void Update(JobDTO obj)
        {
            try
            {
                IEnumerable<JOB> matches =
                    from job in _db.JOBs
                    where job.IDJob == obj.ID
                    select job;
                //_db.MEMBERs.Where(member => member.IDMember == obj.ID)
                //.Select(member);

                JOB jobMapper = matches.SingleOrDefault();
                _updateModel(ref jobMapper, obj);
                this._save();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(JobModel), exc);
                throw new FTreeDbAccessException(exc);
            }
        }

        #endregion

        #region UTILITY METHODS

        internal static JOB ConvertToMapper(JobDTO dto)
        {
            JOB mapper = new JOB();

            _updateModel(ref mapper, dto);

            return mapper;
        }

        internal static JobDTO ConvertToDTO(JOB mapper)
        {
            JobDTO dto = new JobDTO();
            dto.ID = mapper.IDJob;
            dto.Name = mapper.Name;
            dto.Description = mapper.Description;

            return dto;
        }

        private static void _updateModel(ref JOB mapper, JobDTO dto)
        {
            mapper.IDJob = dto.ID;
            mapper.Name = dto.Name;
            mapper.Description = dto.Description;
        }

        #endregion
    }
}
