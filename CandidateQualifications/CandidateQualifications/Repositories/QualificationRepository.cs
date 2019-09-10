using CandidateQualifications.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CandidateQualifications.Repositories
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly AppDbContext context;
        public QualificationRepository(AppDbContext context)
        {
            this.context = context;
        }

        #region "Get Qualifications List"
        /// <summary>
        /// Get List of Qulifications
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Qualification> GetAllQualifications() => context.Qualification.ToList();
        #endregion

        #region "Qualification Details"
        /// <summary>
        /// Get Qualification Details by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Qualification GetQualificationDetails(int Id) => context.Qualification.FirstOrDefault(e => e.Id == Id);
        #endregion

        #region "Add and Edit Qualification Details"
        /// <summary>
        /// Add and Edit Qualification Details
        /// </summary>
        /// <param name="qualification"></param>
        /// <returns></returns>
        public Qualification SaveQualificationDetails(Qualification qualification)
        {
            if (qualification != null)
            {
                if (qualification.Id == 0)
                    context.Qualification.Add(qualification);
                else
                    context.Entry(qualification).State = EntityState.Modified;
                context.SaveChanges();
            }
            return context.Qualification.Where(e => e.Title == qualification.Title).FirstOrDefault();
        }
        #endregion

        #region "Delete Qualification"
        /// <summary>
        /// Delete Qualification by  their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Qualification DeleteQualification(int Id)
        {
            Qualification qualification = context.Qualification.Find(Id);
            if (qualification != null)
            {
                context.Qualification.Remove(qualification);
                context.SaveChanges();
            }
            return qualification;
        }
        #endregion

        #region "Passing Year DropdownList"
        /// <summary>
        /// Displaying PassingYear Dropdownlist having specific year range
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetPassingYearList()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            for (int i = 1990; i <= 2019; i++)
                selectListItems.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            return selectListItems;
        }
        #endregion
    }
    
}
