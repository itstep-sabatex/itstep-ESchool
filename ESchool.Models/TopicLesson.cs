using System;

namespace ESchool.Models
{
    public class TopicLesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateLesson { get; set; }
        public int SubjectId { get; set; }
        public int ScheduleOfLessonId { get; set; }


    }
}
