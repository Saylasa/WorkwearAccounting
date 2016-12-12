using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.DataAccess.Entities;
using WA.Dto;

namespace WA.BusinessLayer
{
    public class DtoConverter
    {
        //WORKWEAR DIRECTORY
        public static WorkwearDirectoryDto Convert(WorkwearDirectory workwearDirectory)
        {
            if (workwearDirectory == null)
                return null;
            WorkwearDirectoryDto workwearDirectoryDto = new WorkwearDirectoryDto();
            workwearDirectoryDto.Id = workwearDirectory.Id;
            workwearDirectoryDto.Name = workwearDirectory.Name;
            workwearDirectoryDto.Category = workwearDirectory.Category;
            workwearDirectoryDto.Description = workwearDirectory.Description;
            workwearDirectoryDto.TimeOfWear = workwearDirectory.TimeOfWear;
            workwearDirectoryDto.Unit = workwearDirectory.Unit;
            return workwearDirectoryDto;
        }

        public static WorkwearDirectory Convert(WorkwearDirectoryDto workwearDirectoryDto)
        {
            if (workwearDirectoryDto == null)
                return null;
            WorkwearDirectory workwearDirectory = new WorkwearDirectory();
            workwearDirectory.Id = workwearDirectoryDto.Id;
            workwearDirectory.Name = workwearDirectoryDto.Name;
            workwearDirectory.Category = workwearDirectoryDto.Category;
            workwearDirectory.Description = workwearDirectoryDto.Description;
            workwearDirectory.TimeOfWear = workwearDirectoryDto.TimeOfWear;
            workwearDirectory.Unit = workwearDirectoryDto.Unit;
            return workwearDirectory;
        }

        public static IList<WorkwearDirectoryDto> Convert(IList<WorkwearDirectory> workwearDirectories)
        {
            if (workwearDirectories == null)
                return null;
            IList<WorkwearDirectoryDto> workwearDirectoryDtos = new List<WorkwearDirectoryDto>();
            foreach (var workwearDirectory in workwearDirectories)
            {
                workwearDirectoryDtos.Add(Convert(workwearDirectory));
            }
            return workwearDirectoryDtos;
        }

        //NORM
        public static NormDto Convert(Norm norm)
        {
            if (norm == null)
                return null;
            NormDto normDto = new NormDto();
            normDto.Id = norm.Id;

            EmplPositionProcessDB s = new EmplPositionProcessDB();
            normDto.EmplPosition = s.Get(norm.Id_EmplPosition);

            WorkwearDirectoryProcessDB s1 = new WorkwearDirectoryProcessDB();
            normDto.WorkwearDirectory = s1.Get(norm.Id_WorkwearDirectory);

            normDto.Amount = norm.Amount;
            return normDto;
        }

        public static Norm Convert(NormDto normDto)
        {
            if (normDto == null)
                return null;
            Norm norm = new Norm();
            norm.Id = normDto.Id;
            norm.Amount = normDto.Amount;
            norm.Id_EmplPosition = normDto.EmplPosition.Id;
            norm.Id_WorkwearDirectory = normDto.WorkwearDirectory.Id;
            return norm;
        }

        public static IList<NormDto> Convert(IList<Norm> norms)
        {
            if (norms == null)
                return null;
            IList<NormDto> normDtos = new List<NormDto>();
            foreach (var norm in norms)
            {
                normDtos.Add(Convert(norm));
            }
            return normDtos;
        }


        //EMPLOYER_POSITION
        public static EmplPositionDto Convert(EmplPosition emplPosition)
        {
            if (emplPosition == null)
                return null;
            EmplPositionDto emplPositionDto = new EmplPositionDto();
            emplPositionDto.Id = emplPosition.Id;

            ManufactoryProcessDB s = new ManufactoryProcessDB();
            emplPositionDto.Manufactory = s.Get(emplPosition.Id_Manufactory);

            emplPositionDto.Name = emplPosition.Name;
            return emplPositionDto;
        }

        public static EmplPosition Convert(EmplPositionDto emplPositionDto)
        {
            if (emplPositionDto == null)
                return null;
            EmplPosition emplPosition = new EmplPosition();
            emplPosition.Id = emplPositionDto.Id;
            emplPosition.Name = emplPositionDto.Name;
            emplPosition.Id_Manufactory = emplPositionDto.Manufactory.Id;
            return emplPosition;
        }

        public static IList<EmplPositionDto> Convert(IList<EmplPosition> emplPositions)
        {
            if (emplPositions == null)
                return null;
            IList<EmplPositionDto> emplPositionDtos = new List<EmplPositionDto>();
            foreach (var emplPosition in emplPositions)
            {
                emplPositionDtos.Add(Convert(emplPosition));
            }
            return emplPositionDtos;
        }


        //MANUFACTORY
        public static ManufactoryDto Convert(Manufactory manufactory)
        {
            if (manufactory == null)
                return null;
            ManufactoryDto manufactoryDto = new ManufactoryDto();
            manufactoryDto.Id = manufactory.Id;
            manufactoryDto.Name = manufactory.Name;
            return manufactoryDto;
        }

        public static Manufactory Convert(ManufactoryDto manufactoryDto)
        {
            if (manufactoryDto == null)
                return null;
            Manufactory manufactory = new Manufactory();
            manufactory.Id = manufactoryDto.Id;
            manufactory.Name = manufactoryDto.Name;
            return manufactory;
        }

        public static IList<ManufactoryDto> Convert(IList<Manufactory> manufactories)
        {
            if (manufactories == null)
                return null;
            IList<ManufactoryDto> manufactoryDtos = new List<ManufactoryDto>();
            foreach (var manufactory in manufactories)
            {
                manufactoryDtos.Add(Convert(manufactory));
            }
            return manufactoryDtos;
        }





    }
}
