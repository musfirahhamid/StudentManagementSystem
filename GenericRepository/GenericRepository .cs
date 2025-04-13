using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;

namespace StudentManagementSystem.GenericRepository
    {
        public class GenericRepository<T> : IGenericRepository<T> where T :  Common
            {
            //The following variable is going to hold the StudentDBContext instance
            private ManagementContext _managementContext = null;
            //The following Variable is going to hold the DbSet Entity
            private DbSet<T> table = null;
            //Using the Parameterless Constructor, 
            //we are initializing the context object and table variable
            public GenericRepository()
                {
                this._managementContext = new ManagementContext();
                //Whatever class name we specify while creating the instance of GenericRepository
                //That class name will be stored in the table variable
                table = _managementContext.Set<T>();
                }
            //Using the Parameterized Constructor, 
            //we are initializing the context object and table variable
            public GenericRepository(ManagementContext _managementContext)
                {
                this._managementContext = _managementContext;
                table = _managementContext.Set<T>();
                }
        //This method will return all the Records from the table
        public IEnumerable<T> GetAll()
            {
            //return table.Where("IsDeleted == false").ToList(); // Dynamic filtering
            return table.ToList();
            
            }
        //This method will return all the active record from the table
        public IQueryable<T> GetAllActive()
            {
            return table.Where(t => !t.IsDeleted).AsQueryable();
            }


        //This method will return all the deleted records from the table
        public IQueryable<T> GetAllDeleted()
            {
            //return table.Where("IsDeleted == true").ToList();
            return table.Where(t => t.IsDeleted).AsQueryable();
            }
        //This method will return the specified record from the table
        public T GetById(object id)
                {
                return table.Find(id);
                }
            //This method will Insert one object into the table
            public void Insert(T obj)
                {
                //It will mark the Entity state as Added State
                table.Add(obj);
                }
            //This method is going to update the record in the table
            public void Update(T obj)
                {
                //First attach the object to the table
                table.Attach(obj);
                //Then set the state of the Entity as Modified
                _managementContext.Entry(obj).State = EntityState.Modified;
                }
        //This method is going to remove the record from the table
        public void Delete(object id)
            {
            T existingRecord = table.Find(id);
            if(existingRecord != null)
                {
                existingRecord.IsDeleted = true;
                _managementContext.Configuration.ValidateOnSaveEnabled = false; // Disable validation
                existingRecord.UpdatedDate = DateTime.UtcNow;
                _managementContext.SaveChanges();
                _managementContext.Configuration.ValidateOnSaveEnabled = true; // Re-enable validation
                }
            else
                {
                throw new InvalidOperationException("Not Found.");
                }
            }


        //This method is going to restore the record from the table
        public void Restore(object id)
            {
            T existingRecord = table.Find(id);
            if(existingRecord != null)
                {
                existingRecord.IsDeleted = false;
                _managementContext.Configuration.ValidateOnSaveEnabled = false; // Disable validation
                existingRecord.UpdatedDate = DateTime.UtcNow;
                _managementContext.SaveChanges();
                _managementContext.Configuration.ValidateOnSaveEnabled = true; // Re-enable validation
                }
            else
                {
                throw new InvalidOperationException("Not Found.");
                }
            }

        //This method will make the changes permanent in the database
        public void Save()
            {
            _managementContext.SaveChanges();
            }
        }
        }
        
        