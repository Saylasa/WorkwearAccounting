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

        //PERSON
        public static PersonDto Convert(Person person)
        {
            if (person == null)
                return null;
            PersonDto personDto = new PersonDto();
            personDto.Id = person.Id;
            personDto.Surname = person.Surname;
            personDto.Name = person.Name;
            personDto.Patronymic = person.Patronymic;
            personDto.Sex = person.Sex;
            personDto.Height = person.Height;
            personDto.ShoeSize = person.ShoeSize;
            personDto.SizeHeadDress = person.SizeHeadDress;
            personDto.SizeGlove = person.SizeGlove;
            personDto.ClothingSize = person.ClothingSize;

            EmplPositionProcessDB s = new EmplPositionProcessDB();
            personDto.Position = s.Get(person.Id_Position);
            return personDto;
        }

        public static Person Convert(PersonDto personDto)
        {
            if (personDto == null)
                return null;
            Person person = new Person();
            person.Id = personDto.Id;
            person.Surname = personDto.Surname;
            person.Name = personDto.Name;
            person.Patronymic = personDto.Patronymic;
            person.Sex = personDto.Sex;
            person.Height = personDto.Height;
            person.ShoeSize = personDto.ShoeSize;
            person.SizeHeadDress = personDto.SizeHeadDress;
            person.SizeGlove = personDto.SizeGlove;
            person.ClothingSize = personDto.ClothingSize;
            person.Id_Position = personDto.Position.Id;
            return person;
        }

        public static IList<PersonDto> Convert(IList<Person> persons)
        {
            if (persons == null)
                return null;
            IList<PersonDto> personDtos = new List<PersonDto>();
            foreach (var person in persons)
            {
                personDtos.Add(Convert(person));
            }
            return personDtos;
        }


        //REVENUE
        public static RevenueDto Convert(Revenue revenue)
        {
            if (revenue == null)
                return null;
            RevenueDto revenueDto = new RevenueDto();
            revenueDto.Id = revenue.Id;
            revenueDto.Issued = revenue.Issued;
            revenueDto.Date_Revenue = revenue.Date_Revenue;
            revenueDto.Clothing_size = revenue.Clothing_size;
            revenueDto.Shoe_size = revenue.Shoe_size;
            revenueDto.Size_Headdress = revenue.Size_Headdress;
            revenueDto.Size_Glove = revenue.Size_Glove;

            WorkwearDirectoryProcessDB s = new WorkwearDirectoryProcessDB();
            revenueDto.WorkwearDirectory = s.Get(revenue.Id_WorkwearDirectory);
            return revenueDto;
        }

        public static Revenue Convert(RevenueDto revenueDto)
        {
            if (revenueDto == null)
                return null;
            Revenue revenue = new Revenue();
            revenue.Id = revenueDto.Id;
            revenue.Issued = revenueDto.Issued;
            revenue.Date_Revenue = revenueDto.Date_Revenue;
            revenue.Clothing_size = revenueDto.Clothing_size;
            revenue.Shoe_size = revenueDto.Shoe_size;
            revenue.Size_Headdress = revenueDto.Size_Headdress;
            revenue.Size_Glove = revenueDto.Size_Glove;
            revenue.Id_WorkwearDirectory = revenueDto.WorkwearDirectory.Id;
            return revenue;
        }

        public static IList<RevenueDto> Convert(IList<Revenue> revenues)
        {
            if (revenues == null)
                return null;
            IList<RevenueDto> revenueDtos = new List<RevenueDto>();
            foreach (var revenue in revenues)
            {
                revenueDtos.Add(Convert(revenue));
            }
            return revenueDtos;
        }

        //ISSUED
        public static IssuedDto Convert(Issued issued)
        {
            if (issued == null)
                return null;
            IssuedDto issuedDto = new IssuedDto();
            issuedDto.Id = issued.Id;
            issuedDto.Cancellation = issued.Cancellation;
            issuedDto.Date_Issued = issued.Date_Issued;

            RevenueProcessDB s = new RevenueProcessDB();
            issuedDto.Revenue = s.Get(issued.Id_Revenue);

            PersonProcessDB s1 = new PersonProcessDB();
            issuedDto.Person = s1.Get(issued.Id_Person);
            return issuedDto;
        }

        public static Issued Convert(IssuedDto issuedDto)
        {
            if (issuedDto == null)
                return null;
            Issued issued = new Issued();
            issued.Id = issuedDto.Id;
            issued.Cancellation = issuedDto.Cancellation;
            issued.Date_Issued = issuedDto.Date_Issued;
            issued.Id_Revenue = issuedDto.Revenue.Id;
            issued.Id_Person = issuedDto.Person.Id;
            return issued;
        }

        public static IList<IssuedDto> Convert(IList<Issued> issueds)
        {
            if (issueds == null)
                return null;
            IList<IssuedDto> issuedDtos = new List<IssuedDto>();
            foreach (var issued in issueds)
            {
                issuedDtos.Add(Convert(issued));
            }
            return issuedDtos;
        }

        //CANCELLATION
        public static CancellationDto Convert(Cancellation cancellation)
        {
            if (cancellation == null)
                return null;
            CancellationDto cancellationDto = new CancellationDto();
            cancellationDto.Id = cancellation.Id;
            cancellationDto.Date_Cancellation = cancellation.Date_Cancellation;

            IssueProcessDB s = new IssueProcessDB();
            cancellationDto.Issued = s.Get(cancellation.Id_Issued);
            return cancellationDto;
        }

        public static Cancellation Convert(CancellationDto cancellationDto)
        {
            if (cancellationDto == null)
                return null;
            Cancellation cancellation = new Cancellation();
            cancellation.Id = cancellationDto.Id;
            cancellation.Date_Cancellation = cancellationDto.Date_Cancellation;
            cancellation.Id_Issued = cancellationDto.Issued.Id;
            return cancellation;
        }

        public static IList<CancellationDto> Convert(IList<Cancellation> cancellations)
        {
            if (cancellations == null)
                return null;
            IList<CancellationDto> cancellationDtos = new List<CancellationDto>();
            foreach (var issued in cancellations)
            {
                cancellationDtos.Add(Convert(issued));
            }
            return cancellationDtos;
        }



    }
}
