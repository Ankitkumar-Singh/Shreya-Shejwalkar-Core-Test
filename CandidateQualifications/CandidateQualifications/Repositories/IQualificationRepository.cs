using CandidateQualifications.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CandidateQualifications.Repositories
{
    public interface IQualificationRepository
    {
        IEnumerable<Qualification> GetAllQualifications();
        Qualification GetQualificationDetails(int Id);

        Qualification SaveQualificationDetails(Qualification qualification);

        Qualification DeleteQualification(int Id);

        List<SelectListItem> GetPassingYearList();

    }
}
