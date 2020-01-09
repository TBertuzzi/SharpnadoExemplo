﻿using System;
using System.Windows.Input;

namespace SharpnadoExemplo.Models
{
    public class Teste
    {
        public Teste(SillyDude dude, ICommand onItemTappedCommand)
        {
            Id = dude.Id;
            Name = dude.Name;
            FullName = dude.FullName;
            Role = dude.Role;
            Description = dude.Description;
            ImageUrl = dude.ImageUrl;
            SillinessDegree = dude.SillinessDegree;
            SourceUrl = dude.SourceUrl;

            OnItemTappedCommand = onItemTappedCommand;
        }

        public ICommand OnItemTappedCommand { get; set; }

        public int Id { get; }

        public string Name { get; }

        public string FullName { get; }

        public string Role { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public int SillinessDegree { get; }

        public string SourceUrl { get; }
    }

    public class SillyDude
    {
        private readonly string _realName;

        public SillyDude(int id, string name, string role, string description, string imageUrl, int sillinessDegree, string filmoMarkdown, string memeUrl, string sourceUrl = null)
        {
            if (sillinessDegree > 5 || sillinessDegree < 0)
            {
                throw new ArgumentException(@"sillinessDegree must be between 0 and 5", nameof(sillinessDegree));
            }

            Id = id;
            _realName = name;
            Role = role;
            Description = description;
            ImageUrl = imageUrl;
            SillinessDegree = sillinessDegree;
            SourceUrl = sourceUrl;
            FilmoMarkdown = filmoMarkdown;
            MemeUrl = memeUrl;
        }

        public int Id { get; }

#if INFINITE_LIST
        public string Name => $"{TruncateName(8)} n°{Id}";
#else
        public string Name => _realName;
#endif

        public string FullName => $"{_realName} n°{Id}";

        public string Role { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public int SillinessDegree { get; }

        public string SourceUrl { get; }

        public string FilmoMarkdown { get; set; }

        public string MemeUrl { get; }

        public SillyDude Clone(int id)
        {
            return new SillyDude(
                id,
                _realName,
                Role,
                Description,
                ImageUrl,
                SillinessDegree,
                FilmoMarkdown,
                MemeUrl,
                SourceUrl);
        }

        private string TruncateName(int maxChars)
        {
            return _realName.Length <= maxChars ? _realName : _realName.Substring(0, maxChars) + "...";
        }
    }
}

