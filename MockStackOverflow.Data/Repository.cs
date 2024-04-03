using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStackOverflow.Data
{
    public class QuestionsRepository
    {
        private string _connectionString;

        public QuestionsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Question> GetAllQuestions()
        {
            using var context = new MockStackOverflowContext(_connectionString);

            return context.Questions.Include(q=>q.QuestionsTags).ThenInclude(qt=>qt.Tag).ToList();
        }
    }



    public class AuthorizationRepository
    {
        private string _connectionString;

        public AuthorizationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddUser(User user)
        {
            using var context = new MockStackOverflowContext(_connectionString);

            user.Password= BCrypt.Net.BCrypt.HashPassword(user.Password);

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
