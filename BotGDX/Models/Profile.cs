﻿/*
MIT License

Copyright (c) WBot-Soft

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*/

using System;
using System.Collections.Generic;

namespace BotGDX.Models;

public class Profile
{
	public string Name { get; set; }
	public string ProfilePictureFilePath { get; set; }
	public GameList Games { get; set; }
	public List<Tag> Tags { get; set; }
	public Settings Settings { get; set; }
	public string ProfileUuid { get; set; }

	public Profile(string name)
	{
		Name = name;
		ProfilePictureFilePath = "";
		ProfileUuid = Guid.NewGuid().ToString();
		Games = new();
		Tags = new();
		Settings = new();
	}

	public Profile()
	{
		Name = Environment.UserName;
		ProfilePictureFilePath = "";
		ProfileUuid = Guid.NewGuid().ToString();
		Games = new();
		Tags = new();
		Settings = new();
	}

	public override bool Equals(object? obj)
	{
		return obj is Profile profile && ProfileUuid == profile.ProfileUuid;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Name, ProfilePictureFilePath, Games, Tags, Settings, ProfileUuid);
	}
}