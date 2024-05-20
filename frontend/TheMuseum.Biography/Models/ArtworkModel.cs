﻿using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TheMuseum.Biography.Models;

internal class ArtworkModel : ReactiveObject
{
    [Reactive] public int Id { get; set; }
    [Reactive] public string Name { get; set; }
    [Reactive] public string? Description { get; set; }

}
