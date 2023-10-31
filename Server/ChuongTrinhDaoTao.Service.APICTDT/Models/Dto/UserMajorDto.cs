﻿using ChuongTrinhDaoTao.Service.APICTDT.Data;

namespace ChuongTrinhDaoTao.Service.APICTDT.Models.Dto
{
    public class UserMajorDto
    {
        public  string UserId { get; set; }
        public int MajorId { get; set; }

        public int CohortId { get; set; }
        public virtual Cohort? Cohort { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual Major? Major { get; set; }
    }
}
