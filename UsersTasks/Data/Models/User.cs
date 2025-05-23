﻿namespace UsersTasks.API.Data.Models
{
	public class User
	{
		public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Email { get; set; }
		public DateTime CreatedAt { get; set; }
		public ICollection<AppTask>? Tasks { get; set; }
	}
}
