﻿namespace ExaminationSystem.Models
{
    public class Question:BaseModel
    {
        public Question() 
        { 
            Choices = new List<Choice>();        
        }

        public string Body { get; set; }
        public int Grade { get; set; }
        public string level { get; set; }

        public ICollection<Choice> Choices { get; set; }

        public Answer Answer { get; set; }

    }
}
