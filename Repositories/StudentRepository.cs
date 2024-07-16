using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextClass _dbContext;

        public StudentRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var result = _dbContext.Students.Add(studentDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var filteredData = _dbContext.Students.Where(x => x.Id == Id).FirstOrDefault();
            if (filteredData != null)
            {
                _dbContext.Students.Remove(filteredData);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<StudentDetails?> GetStudentByIdAsync(int Id)
        {
            StudentDetails? studentDetails = await _dbContext.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (studentDetails != null)
            {
                return studentDetails;
            }
            return null;
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            _dbContext.Students.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
