using guitar_shop_api.Base.Models;
using guitar_shop_api.Models;
using guitar_shop_api.Repositories;

namespace guitar_shop_api.Services
{
    public class GuitarService
    {
        private readonly GuitarRepository _guitarRepository;

        public GuitarService(GuitarRepository guitarRepository)
        {
            _guitarRepository = guitarRepository;
        }

        public async Task<Result<bool>> Create(GuitarModel guitarModel)
        {
            try
            {
                var result = await _guitarRepository.Create(guitarModel);

                if(!result) return Result<bool>.Fail("Error");

                return Result<bool>.Ok("Success");
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail($"Error: {ex.Message}");
            }
        }

        public async Task<Result<IEnumerable<GuitarModel>>> Get()
        {
            try
            {
                var result = await _guitarRepository.Get();

                if (result.Count() <= 0) return Result<IEnumerable<GuitarModel>>.Fail("Error");

                return Result<IEnumerable<GuitarModel>>.Ok("Success", result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<GuitarModel>>.Fail($"Error: {ex.Message}");
            }
        }

        public async Task<Result<IEnumerable<GuitarModel>>> GetById(long id)
        {
            try
            {
                var result = await _guitarRepository.GetById(id);

                if (result.Count() <= 0) return Result<IEnumerable<GuitarModel>>.Fail("Error");

                return Result<IEnumerable<GuitarModel>>.Ok("Success", result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<GuitarModel>>.Fail($"Error: {ex.Message}");
            }
        }

        public async Task<Result<bool>> Update(GuitarModel guitarModel)
        {
            try
            {
                var result = await _guitarRepository.Update(guitarModel);

                if (!result) return Result<bool>.Fail("Error");

                return Result<bool>.Ok("Success");
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail($"Error: {ex.Message}");
            }
        }
        public async Task<Result<bool>> Delete(long id)
        {
            try
            {
                var result = await _guitarRepository.Delete(id);

                if (!result) return Result<bool>.Fail("Error");

                return Result<bool>.Ok("Success");
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail($"Error: {ex.Message}");
            }
        }

    }
}
