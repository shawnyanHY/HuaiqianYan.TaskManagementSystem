﻿using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class UserResponseModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string MobileNo { get; set; }

        public IEnumerable<TaskHistoryResponseModel> TaskHistories { get; set; }

        public IEnumerable<TaskResponseModel> Tasks { get; set; }
    }

    public class UserInfoResponseModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string MobileNo { get; set; }

        public string Token { get; set; }
    }

    public class TaskResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public char? Priority { get; set; }

        public string Remarks { get; set; }

        public UserResponseModel User { get; set; }
    }

    public class TaskHistoryResponseModel
    {
        public int TaskId { get; set; }

        public int? UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? Completed { get; set; }

        public string Remarks { get; set; }

        public UserResponseModel User { get; set; }
    }
}
