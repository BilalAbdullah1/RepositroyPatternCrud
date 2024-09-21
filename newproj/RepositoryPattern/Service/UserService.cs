using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using newproj.Data;
using newproj.Models;
using newproj.RepositoryPattern.Interface;
using System.Runtime.InteropServices;

namespace newproj.RepositoryPattern.Service
{
    public class UserService : IUsers
    {
        private readonly CrudContext _context;
        public UserService(CrudContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            var userdata = await _context.users.ToListAsync();
            return userdata;
        }

        public async Task<int> UserCreate(Users Usr, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(image.FileName);
                    string imgfolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "myfiles");

                    if (!Directory.Exists(imgfolder))
                    {
                        Directory.CreateDirectory(imgfolder);
                    }

                    string filePath = Path.Combine(imgfolder, fileName);


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }


                    string upload = Path.Combine("myfiles", fileName);
                    Usr.ProfilePicture = upload;


                    await _context.users.AddAsync(Usr);
                    await _context.SaveChangesAsync();
                    return Usr.userId;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return 0;
            }
        }
        public async Task<Users> GetUserById(int id)
        { 
            var data = await _context.users.Where(x => x.userId == id).FirstOrDefaultAsync();
            return data;
        }
        public async Task<int> UserUpdate(Users Usr, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(image.FileName);
                    string imgfolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "myfiles");

                    if (!Directory.Exists(imgfolder))
                    {
                        Directory.CreateDirectory(imgfolder);
                    }

                    string filePath = Path.Combine(imgfolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    string upload = Path.Combine("myfiles", fileName);
                    Usr.ProfilePicture = upload;


                    _context.users.Update(Usr);
                    await _context.SaveChangesAsync();
                    return Usr.userId;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return 0;
            }
        }

        public async Task<Users> GetUserDeleteById(int id)
        {
            var data = await _context.users.Where(x => x.userId == id).FirstOrDefaultAsync();
            _context.users.Remove(data);
            _context.SaveChanges();
            return data;
        }
    }
}
