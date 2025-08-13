using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.EntityModels.SchoolModel;
using DataModels.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Infrastructure.School
{
    public class ClService
    {
        #region Variable declaration & initialization
        AdmissionContext _ctx = null;
        #endregion

        #region All Methods

        /// <summary>
        /// This method returns an object from database as object with pagination using asynchronous operation by vmInvParameters class as parameter.
        /// </summary>
        /// <param name="cmnParam"></param>
        /// <returns></returns>
        public async Task<object> GetWithPage(vmCmnParameters cmnParam)
        {
            List<Class> listClass = null; object result = null; int recordsTotal = 0;

            try
            {
                using (_ctx = new AdmissionContext())
                {
                    listClass = await _ctx.Class
                        .OrderByDescending(x => x.ClassId)
                        .Skip(Conversions.Skip(cmnParam))
                        .Take((int)cmnParam.pageSize)
                        .ToListAsync();
                    recordsTotal = await _ctx.Class.CountAsync();
                }
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return result = new
            {
                listClass,
                recordsTotal
            };
        }


        /// <summary>
        /// This method returns data from database as an object using asynchronous operation by an int parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<object> GetByID(int id)
        {
            Class objClass = null; object result = null;
            try
            {
                using (_ctx = new AdmissionContext())
                {
                    objClass = await _ctx.Class.Where(x => x.ClassId == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return result = new
            {
                objClass
            };

        }


        /// <summary>
        /// Both insert and update can perform by BizIspPopzone model in database using asynchronous operation. when id is more than 0 update is performed otherwise insert. it returns an object as status of success or failure.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<object> SaveUpdate(Class model)
        {
            object result = null; string message = string.Empty; bool resstate = false;
            var objClass = new Class();
            using (_ctx = new AdmissionContext())
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (model.ClassId > 0) // update
                        {
                            objClass = await _ctx.Class.Where(x => x.ClassId == model.ClassId).FirstOrDefaultAsync();
                            objClass.Name = model.Name;
                        }
                        else
                        {
                            //var MaxID = _ctx.Section.DefaultIfEmpty().Max(x => x == null ? 0 : x.SectionId) + 1;
                            //objSection.SectionId = MaxID; // custom auto number
                            objClass.Name = model.Name;

                            await _ctx.Class.AddAsync(objClass);
                        }

                        await _ctx.SaveChangesAsync();

                        _ctxTransaction.Commit();
                        message = MessageConstants.Saved;
                        resstate = MessageConstants.SuccessState;
                    }
                    catch (Exception ex)
                    {
                        _ctxTransaction.Rollback();
                        //Logs.WriteBug(ex);
                        message = MessageConstants.SavedWarning;
                        resstate = MessageConstants.ErrorState;
                    }
                }
            }
            return result = new
            {
                message,
                resstate
            };
        }

        /// <summary>
        /// Delete can perform to table by int parameter in database using asynchronous operation. It returns an object as status of success or failure.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<object> Delete(int id)
        {
            object result = null; string message = string.Empty; bool resstate = false;
            using (_ctx = new AdmissionContext())
            {
                using (var _ctxTran = await _ctx.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (id > 0)
                        {
                            var delModel = await _ctx.Class.Where(x => x.ClassId == id).FirstOrDefaultAsync();
                            _ctx.Class.Remove(delModel);
                        }

                        await _ctx.SaveChangesAsync();
                        _ctxTran.Commit();
                        message = MessageConstants.Deleted;
                        resstate = MessageConstants.SuccessState;
                    }
                    catch (Exception ex)
                    {
                        _ctxTran.Rollback();
                        //Logs.WriteBug(ex);
                        message = MessageConstants.DeletedWarning;
                        resstate = MessageConstants.ErrorState;
                    }
                }
            }
            return result = new
            {
                message,
                resstate
            };
        }
        #endregion

    }
}
