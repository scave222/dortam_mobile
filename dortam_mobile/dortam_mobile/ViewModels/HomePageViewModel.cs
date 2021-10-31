using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace dortam_mobile.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            Onboardings = GetOnboarding();
            Plans = GetPlans();
        }
        public List<Onboarding> Onboardings { get; set; }
        public List<Plan> Plans { get; set; }

        public List<Plan> GetPlans()
        {
            return new List<Plan>
            {
                new Plan{ PlanName ="Siver Plan",Description="Up to 5% for 20 Hourly Compound Available Down to 5% for 20 Hourly Principal Return Up to 5 % for 20 Hourly",Color=Color.Purple},
                new Plan{ PlanName ="Bronze Plan",Description="Up to 5% Daily for 5 Days Min deposit: $2020 Max deposit: $101010 Principal Return Compound Available",Color=Color.SkyBlue},
                new Plan{ PlanName ="Copper Plan",Description="Up to 3% Hourly for 10 Hourly Min deposit: $300 Max deposit: $3000 Principal Not Return Compound Not Available",Color=Color.OrangeRed},
                new Plan{ PlanName ="Gold Plan",Description="Up to 7% for 30 days Min deposit: $500 Max deposit: $3000 Principal Not Return Compound Available",Color=Color.Gold}
            };
        }

        private List<Onboarding> GetOnboarding()
        {
            return new List<Onboarding>
            {
                new Onboarding{Heading="Create events in minutes",Caption="From small birthday parties with friends to large community events."},
                new Onboarding{Heading="Your events in one place",Caption="Manage all your events in one single place to always get a reminder."},
                new Onboarding{Heading="Explore events arround you",Caption="Select any events that interest you from a list of aesome event."}
            };
        }
    }
    public class Onboarding
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
    }
    public class Plan
    {
        public string PlanName { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
    }
}
