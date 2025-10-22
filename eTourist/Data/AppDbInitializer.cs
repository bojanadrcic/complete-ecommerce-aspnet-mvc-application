using eTourist.Models;

namespace eTourist.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //Destination
                if (!context.Destinations.Any())
                {
                    context.Destinations.AddRange(new List<Destination>()
                    {
                        new Destination ()
                        {
                            Picture = "Picture 1",
                            Name= "Name 1",
                            Description = "Description 1"

                        },

                        new Destination () {
                            Picture = "Picture 2",
                            Name= "Name 2",
                            Description = "Description 2"
                        },
                        new Destination () {
                            Picture = "Picture 3",
                            Name= "Name 3",
                            Description = "Description 3"
                        },
                        new Destination () {
                            Picture = "Picture 4",
                            Name= "Name 4",
                            Description = "Description 4"
                        },
                        new Destination () {
                            Picture = "Picture 5",
                            Name= "Name 5",
                            Description = "Description 5"
                        }

                    });
                    context.SaveChanges();
                }
                //TourGuide
                if (!context.TourGuides.Any())
                {
                    context.TourGuides.AddRange(new List<TourGuide>()
                    {
                        new TourGuide ()
                        {
                            ProfilePictureURL = "Picture 1",
                            FullName= "Name 1",
                            Bio = "Bio 1"

                        },

                       new TourGuide ()
                        {
                            ProfilePictureURL = "Picture 2",
                            FullName= "Name 2",
                            Bio = "Bio 2"

                        },
                        new TourGuide ()
                        {
                            ProfilePictureURL = "Picture 3",
                            FullName= "Name 3",
                            Bio = "Bio 3"

                        },
                        new TourGuide ()
                        {
                            ProfilePictureURL = "Picture 4",
                            FullName= "Name 4",
                            Bio = "Bio 4"

                        },
                        new TourGuide ()
                        {
                            ProfilePictureURL = "Picture 5",
                            FullName= "Name 5",
                            Bio = "Bio 5"

                        }

                    });
                    context.SaveChanges();
                }


                //TravelAgency
                if (!context.TravelAgencies.Any())
                {
                    context.TravelAgencies.AddRange(new List<TravelAgency>()
                    {
                        new TravelAgency ()
                        {
                            ProfilePictureURL = "Picture 1",
                            FullName= "Name 1",
                            Bio = "Bio 1"

                        },

                        new TravelAgency ()
                        {
                            ProfilePictureURL = "Picture 2",
                            FullName= "Name 2",
                            Bio = "Bio 2"

                        },
                        
                        new TravelAgency ()
                        {
                            ProfilePictureURL = "Picture 3",
                            FullName= "Name 3",
                            Bio = "Bio 3"

                        },
                        new TravelAgency ()
                        {
                            ProfilePictureURL = "Picture 4",
                            FullName= "Name 4",
                            Bio = "Bio 4"

                        },

                        new TravelAgency ()
                        {
                            ProfilePictureURL = "Picture 5",
                            FullName= "Name 5",
                            Bio = "Bio 5"

                        },

                    });
                    context.SaveChanges();
                }
                //Arrangements
                if (!context.Arrangements.Any())
                {
                    context.Arrangements.AddRange(new List<Arrangement>()
                    {
                        new Arrangement ()
                        {
                            Name= "Name 1",
                            Description = "Description 1",
                            Price = 1,
                            ImageURL = "ImageURl",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            DestinationId = 1,
                            TravelAgencyId = 1,
                            ArrangementCategory = Enums.ArrangementCategory.SummerTrips
                        },


                        new Arrangement ()
                        {
                            Name= "Name 2",
                            Description = "Description 1",
                            Price = 1,
                            ImageURL = "ImageURl",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            DestinationId = 2,
                            TravelAgencyId = 2,
                            ArrangementCategory = Enums.ArrangementCategory.WinterTrips
                        },

                        new Arrangement ()
                        {
                            Name= "Name 3",
                            Description = "Description 3",
                            Price = 1,
                            ImageURL = "ImageURl",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            DestinationId = 3,
                            TravelAgencyId = 3,
                            ArrangementCategory = Enums.ArrangementCategory.SummerTrips
                        },

                        new Arrangement ()
                        {
                            Name= "Name 4",
                            Description = "Description 4",
                            Price = 1,
                            ImageURL = "ImageURl",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            DestinationId = 4,
                            TravelAgencyId = 4,
                            ArrangementCategory = Enums.ArrangementCategory.SummerTrips
                        },

                          new Arrangement ()
                        {
                            Name= "Name 5",
                            Description = "Description 5",
                            Price = 1,
                            ImageURL = "ImageURl",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            DestinationId = 5,
                            TravelAgencyId = 5,
                            ArrangementCategory = Enums.ArrangementCategory.SummerTrips
                        }

                    });
                    context.SaveChanges();
                }
                //TourGuide & Arrangements
                if (!context.TourGuides_Arrangements.Any())
                {
                    context.TourGuides_Arrangements.AddRange(new List<TourGuide_Arrangement>()
                    {
                    new TourGuide_Arrangement()
                    {
                        TourGuideId = 1,
                        ArrangementId = 1
                    },

                    new TourGuide_Arrangement()
                    {
                        TourGuideId = 2,
                        ArrangementId = 2
                    },

                    new TourGuide_Arrangement()
                    {
                        TourGuideId = 3,
                        ArrangementId = 3
                    },

                    new TourGuide_Arrangement()
                    {
                        TourGuideId = 4,
                        ArrangementId = 4
                    },

                    new TourGuide_Arrangement()
                    {
                        TourGuideId = 5,
                        ArrangementId = 5
                    },
                });
                    context.SaveChanges();
                }
                
            }
        }
    }
}
