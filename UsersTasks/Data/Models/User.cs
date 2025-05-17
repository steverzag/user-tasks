﻿namespace UsersTasks.API.Data.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime CreatedAt { get; set; }
		public ICollection<AppTask> Tasks { get; set; }
	}
}
