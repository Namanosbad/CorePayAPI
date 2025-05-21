using CorePayAPI.Data;
using CorePayAPI.DTOs.Requests;
using CorePayAPI.Entities.CorePayDB;
using CorePayAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace CorePayAPI.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly CorePayDb _context;

        public TransferRepository(CorePayDb context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
