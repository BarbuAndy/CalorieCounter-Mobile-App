using CC.DbModels;
using CC.Helpers;
using CC.Queries;
using CC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace CC.Repository
{
    public class UserRepository : IBaseRepository<User, UserQuery>
    {
        private readonly CCDbContext _dbContext;
        private readonly IPasswordHasher<User> passHash;
        private readonly AppSettings appSettings;
        public UserRepository(CCDbContext dbContext, PasswordHasher<User> passwordHasher, IOptions<AppSettings> appSettings)
        {
            this._dbContext = dbContext;
            passHash = passwordHasher;
            this.appSettings = appSettings.Value;
        }

        public void Add(User e)
        {
            e.passwordHash = passHash.HashPassword(e,e.password);
            //e.password = "";
            e.role = "user";
            _dbContext.Add(e);
            _dbContext.SaveChanges();
        }

        public void Delete(User e)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Get(UserQuery req)
        {
            IQueryable<User> query = this._dbContext.User.AsQueryable();
            if(req.userId != 0)
            {
                query = query.Where(e => e.userId == req.userId);
            }
            if (!string.IsNullOrEmpty(req.email))
            {
                query = query.Where(e => e.email.Contains(req.email));
            }
            if (!string.IsNullOrWhiteSpace(req.firstName))
            {
                query = query.Where(e => e.firstName == req.firstName);
            }
            if (!string.IsNullOrWhiteSpace(req.lastName))
            {
                query = query.Where(e => e.lastName == req.lastName);
            }
            if (!string.IsNullOrWhiteSpace(req.role))
            {
                query = query.Where(e => e.role == req.role);
            }
            return query.AsEnumerable();
        }

        public bool CheckUniqueEmail(string email)
        {
            return this._dbContext.User.AsQueryable().FirstOrDefault(e => e.email == email) == null;
        }

        public void Update(User e)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.userId == e.userId);
            var hashCheck = passHash.VerifyHashedPassword(user, user.passwordHash, e.password);
            if (hashCheck == PasswordVerificationResult.Failed)
                throw new Exception("password does not match");

            _dbContext.Entry(user).CurrentValues.SetValues(e);
            _dbContext.SaveChanges();
        }

        public User Login(string email, string password)
        {
            var user = _dbContext.User.AsQueryable().SingleOrDefault(e => e.email == email);
            if (user == null)
                return null;

            var hashCheck = passHash.VerifyHashedPassword(user, user.passwordHash, password);
            if (hashCheck == PasswordVerificationResult.Failed)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1000),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.userId.ToString()),
                    new Claim("role", user.role.ToString())
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user;

        }
    }
}