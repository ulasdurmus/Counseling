using Counseling.Data.Abstract;
using Counseling.Data.Concrete.Context;
using Counseling.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.EfCoreRepositories
{
    public class EfCoreImageRepository : EfCoreGenericrepository<Image>, IImageRepository
    {
        public EfCoreImageRepository(CounselingContext _appContext) : base(_appContext)
        {
        }
        CounselingContext AppContext
        {
            get { return _dbContext as CounselingContext; }
        }

        public int CheckImageName(string imageName)
        {
            bool result = true;
            int count = 0;
            while (result)
            {
                if (count < 1)
                {
                    result = AppContext
                .Images
                .Any(i => i.Url == imageName);
                }
                if (result)
                {
                    count++;
                    result = AppContext
                        .Images
                        .Where(i => i.Url.Contains($"({count})"))
                        .Any();
                }
            }

            return count;
        }
    }
}
