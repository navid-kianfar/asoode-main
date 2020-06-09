using System;
using System.Linq;
using System.Threading.Tasks;
using Asoode.Main.Core.Contracts.General;
using Asoode.Main.Core.Contracts.Logging;
using Asoode.Main.Core.Primitives;
using Asoode.Main.Core.ViewModel.General;
using Asoode.Main.Data.Contexts;
using Asoode.Main.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asoode.Main.Business.General
{
    internal class TestimonialBiz : ITestimonailBiz
    {
        private readonly IServiceProvider _serviceProvider;

        public TestimonialBiz(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<OperationResult<TestimonialViewModel[]>> Top5(string culture)
        {
            try
            {
                using (var unit = _serviceProvider.GetService<ApplicationDbContext>())
                {
                    var testimonials = await (
                        from testimonial in unit.Testimonials
                        join usr in unit.Users on testimonial.UserId equals usr.Id
                        where testimonial.Approved && testimonial.Culture == culture
                        orderby testimonial.CreatedAt descending 
                        select new { User = usr, Testimonial = testimonial }
                    ).AsNoTracking()
                    .ToArrayAsync();
                    
                    var result = testimonials.Select(t => new TestimonialViewModel
                    {
                        Avatar = t.User.Avatar,
                        Bio = t.User.Bio,
                        FullName = t.User.FullName,
                        Approved = t.Testimonial.Approved,
                        Culture = t.Testimonial.Culture,
                        Id = t.Testimonial.Id,
                        Message = t.Testimonial.Message,
                        Rate = t.Testimonial.Rate,
                        CreatedAt = t.Testimonial.CreatedAt,
                        UpdatedAt = t.Testimonial.UpdatedAt,
                        UserId = t.Testimonial.UserId
                    }).ToArray();

                    if (!result.Any())
                    {
                        result = new[]
                        {
                            new TestimonialViewModel
                            {
                                Avatar = null,
                                Bio = "کارشناس فروش",
                                FullName = "مصطفی محمدپور",
                                Message = "به آسودگی! دیگه هرکی ازم بپرسه: چطوری تونستی زندگی و کسب و کارات به بهترین شکل مدیریت و برنامه ریزی کنی میگم با آسوده! یقین دارم بیشتر از شما خواهیم شنید.",
                                Approved = true,
                                Culture = culture,
                                Id = Guid.Empty,
                                Rate = 5,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = null,
                                UserId = Guid.Empty
                            },
                            new TestimonialViewModel
                            {
                                Avatar = null,
                                Bio = "تکنسین برق",
                                FullName = "علی زمانی",
                                Message = "با سلام و خسته نباشید خدمت مدیریت سایت آسوده باید بگم که با یک برنامه بسیار کاربردی با کارایی ساده برخورد کردم و فکر میکنم می‌تونه جایگاه خودش رو تو جامعه داشته باشه. خدا قوت",
                                Approved = true,
                                Culture = culture,
                                Id = Guid.Empty,
                                Rate = 5,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = null,
                                UserId = Guid.Empty
                            },
                        };
                    }
                    
                    return OperationResult<TestimonialViewModel[]>.Success(result);
                }
            }
            catch (Exception ex)
            {
                await _serviceProvider.GetService<IErrorBiz>().LogException(ex);
                return OperationResult<TestimonialViewModel[]>.Failed();
            }
        }
    }
}