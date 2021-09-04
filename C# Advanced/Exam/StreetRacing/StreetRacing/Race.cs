﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(
            string name,
            string type,
            int laps,
            int capacity,
            int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;

            this.Participants = new HashSet<Car>();
        }

        public HashSet<Car> Participants { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (!this.Participants.Any(p => p.LicensePlate == car.LicensePlate) &&
                                            this.Count < this.Capacity &&
                                            car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car car = this.FindParticipant(licensePlate);

            if (car is null)
            {
                return false;
            }
            else
            {
                return this.Participants.Remove(car);
            }
        }
        
        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.FirstOrDefault(p => p.LicensePlate == licensePlate);
        } 
        
        public Car GetMostPowerfulCar()
        {
            return this.Participants.OrderByDescending(p => p.HorsePower).FirstOrDefault();
        } 
        
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (Car participant in this.Participants)
            {
                sb.AppendLine(participant.ToString());
            }

            return sb.ToString().TrimEnd();
        } 
    }
}