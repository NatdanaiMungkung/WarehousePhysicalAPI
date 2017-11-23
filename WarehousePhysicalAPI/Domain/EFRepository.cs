using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using WarehousePhysicalAPI.Models;

namespace WarehousePhysicalAPI.Domain
{
    public class EFRepository : IEFDbRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Users> Users {get { return context.Users; }}
        public IEnumerable<Attributes> Attributes { get { return context.Attributes; } }

        public IEnumerable<ReconcileGroup> ReconcileGroup { get { return context.ReconcileGroup; } }

        public IEnumerable<Statuses> Statuses { get { return context.Statuses; } }

        public IEnumerable<StandardPrices> StandardPrices { get { return context.StandardPrices; } }

        public IEnumerable<Jobs> Jobs { get { return context.Jobs; } }

        public IEnumerable<SAPInputs> SAPInputs { get { return context.SAPInputs; } }

        public IEnumerable<ReconcileInputs> ReconcileInputs { get { return context.ReconcileInputs; } }

        public IEnumerable<ItileInputs> ItileInputs { get { return context.ItileInputs; } }

        public IEnumerable<ResultInputs> ResultInputs { get { return context.ResultInputs; } }

        public Users CheckLogin(Users data)
        {
            return context.Users.FirstOrDefault(a => a.UserName == data.UserName && a.PassWord == data.PassWord);
        }

        public int SaveUser(Users data)
        {
            try
            {
                if(data.Id == 0)
                    context.Users.Add(data);
                else
                {
                    var toUpdate = context.Users.FirstOrDefault(a => a.Id == data.Id);
                    toUpdate.PassWord = data.PassWord;
                    toUpdate.FirstName = data.FirstName;
                    toUpdate.LastName = data.LastName;
                    toUpdate.Enable = data.Enable;
                    toUpdate.IsAdmin = data.IsAdmin;
                }
                context.SaveChanges();
                return data.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int SaveAttribute(Attributes data)
        {
            try
            {
                if (data.Id == 0)
                    context.Attributes.Add(data);
                else
                {
                    var toUpdate = context.Attributes.FirstOrDefault(a => a.Id == data.Id);
                    toUpdate.Attribute = data.Attribute;
                    toUpdate.Description = data.Description;
                    toUpdate.WHDPlant = data.WHDPlant;
                    toUpdate.WHDSloc = data.WHDSloc;
                    toUpdate.WHEPlant = data.WHEPlant;
                    toUpdate.WHESloc = data.WHESloc;
                }
                context.SaveChanges();
                return data.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool DeleteAttribute(int data)
        {
            var toDelete = context.Attributes.FirstOrDefault(a => a.Id == data);
            try
            {
                context.Attributes.Remove(toDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int SaveReconcileGroup(ReconcileGroup data)
        {
            try
            {
                if (data.Id == 0)
                {
                    data.CreatedDate = DateTime.Now;
                    context.ReconcileGroup.Add(data);

                }
                    
                else
                {
                    var toUpdate = context.ReconcileGroup.FirstOrDefault(a => a.Id == data.Id);
                    toUpdate.ReconcileGroupId = data.ReconcileGroupId;
                    toUpdate.ReconcileGroupName = data.ReconcileGroupName;
                    toUpdate.ReconcileType = data.ReconcileType;
                    toUpdate.ReconcileTypeName = data.ReconcileTypeName;
                    toUpdate.ResponseUserId = data.ResponseUserId;
                    toUpdate.Sign = data.Sign;
                    toUpdate.LastChangedDate = DateTime.Now;
                }
                context.SaveChanges();
                return data.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool DeleteReconcileGroup(int data)
        {
            var toDelete = context.ReconcileGroup.FirstOrDefault(a => a.Id == data);
            try
            {
                context.ReconcileGroup.Remove(toDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int SaveStatus(Statuses data)
        {
            try
            {
                if (data.Id == 0)
                    context.Statuses.Add(data);
                else
                {
                    var toUpdate = context.Statuses.FirstOrDefault(a => a.Id == data.Id);
                    toUpdate.StatusId = data.StatusId;
                    toUpdate.StatusDescription = data.StatusDescription;
                }
                context.SaveChanges();
                return data.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool DeleteStatus(int data)
        {
            var toDelete = context.Statuses.FirstOrDefault(a => a.Id == data);
            try
            {
                context.Statuses.Remove(toDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ChangePassword(string userName,string oldPass, string newPass)
        {
            
            var toUpdate = context.Users.FirstOrDefault(a => a.UserName == userName && a.PassWord == oldPass);
            if (toUpdate == null)
                return false;
            toUpdate.PassWord = newPass;
            try
            {
                context.SaveChanges();
                
            }
            catch (Exception ex)
            { return false; }
            return true;
        }

        public int SaveStandardPrices(StandardPrices data)
        {
            try
            {
                if (data.Id == 0)
                    context.StandardPrices.Add(data);
                else
                {
                    var toUpdate = context.StandardPrices.FirstOrDefault(a => a.Id == data.Id);
                    toUpdate.Currency = data.Currency;
                    toUpdate.Description = data.Description;
                    toUpdate.MaterialCode = data.MaterialCode;
                    toUpdate.Plant = data.Plant;
                    toUpdate.PricePerUnit = data.PricePerUnit;
                    toUpdate.Type = data.Type;
                }
                context.SaveChanges();
                return data.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool DeleteStandardPrices(int data)
        {
            var toDelete = context.StandardPrices.FirstOrDefault(a => a.Id == data);
            try
            {
                context.StandardPrices.Remove(toDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Jobs SaveNewJob(JobRequestModel data)
        {
            var lastJob = context.Jobs.Where(a => a.JobName.Contains(data.Prefix) && DbFunctions.TruncateTime(a.CreatedDate) == DbFunctions.TruncateTime(DateTime.Now))?.OrderByDescending(a => a.CreatedDate).FirstOrDefault();
            int lastRunningNo = 1;
            if (lastJob != null)
            {
                lastRunningNo = Convert.ToInt32(lastJob.JobName.Substring(lastJob.JobName.Length - 3));
                lastRunningNo++;
            }
            var job = new Models.Jobs
            {
                CreatedById = data.RequesterUserId,
                CreatedDate = DateTime.Now,
                WarehouseType = data.Prefix == "WHD" ? 1 : 2,
                Id = 0,
                JobName = data.Prefix + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + lastRunningNo.ToString().PadLeft(2, '0')
            };
            context.Jobs.Add(job);
            context.SaveChanges();
            return job;
        }

        public bool SaveSapInput(List<SAPInputs> data)
        {
            try
            {
                var jobId = data[0].JobId;
                var existData = context.SAPInputs.Where(a => a.JobId == jobId);
                if (existData != null)
                {
                    foreach (var each in existData)
                    {
                        context.SAPInputs.Remove(each);
                    }
                    context.SaveChanges();
                }
                foreach (var each in data)
                {
                    context.SAPInputs.Add(each);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveReconcileInput(List<ReconcileInputs> data)
        {
            try
            {
                var jobId = data[0].JobId;
                var existData = context.ReconcileInputs.Where(a => a.JobId == jobId);
                if (existData != null)
                {
                    foreach (var each in existData)
                    {
                        context.ReconcileInputs.Remove(each);
                    }
                    context.SaveChanges();
                }
                foreach (var each in data)
                {
                    context.ReconcileInputs.Add(each);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveItileInput(List<ItileInputs> data)
        {
            try
            {
                var jobId = data[0].JobId;
                var existData = context.ItileInputs.Where(a => a.JobId == jobId);
                if (existData != null)
                {
                    foreach (var each in existData)
                    {
                        context.ItileInputs.Remove(each);
                    }
                    context.SaveChanges();
                }
                foreach (var each in data)
                {
                    context.ItileInputs.Add(each);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveResultInput(List<ResultInputs> data)
        {
            try
            {
                var jobId = data[0].JobId;
                var existData = context.ResultInputs.Where(a => a.JobId == jobId);
                if (existData != null)
                {
                    foreach (var each in existData)
                    {
                        context.ResultInputs.Remove(each);
                    }
                    context.SaveChanges();
                }
                foreach (var each in data)
                {
                    context.ResultInputs.Add(each);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}