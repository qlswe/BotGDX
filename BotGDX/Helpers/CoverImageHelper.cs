/*
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

using PeyrSharp.Env;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotGDX.Helpers;

public class CoverImageHelper
{
	private readonly string _url;
	private readonly int _id;
	private readonly int _gameId;

	public CoverImageHelper(string url, int id, int gameId)
	{
		_url = url;
		_id = id;
		_gameId = gameId;
	}

	public async Task<string> Download()
	{

		if (!Directory.Exists(FileSys.AppDataPath + @"\WBot-Soft\BotGDX\Games")) // If the directory doesn't exist
		{
			Directory.CreateDirectory(FileSys.AppDataPath + @"\WBot-Soft\BotGDX\Games"); // Create the direspctory
		}

		if (!Directory.Exists(FileSys.AppDataPath + @$"\WBot-Soft\BotGDX\games\{_gameId}")) // If the directory doesn't exist
		{
			Directory.CreateDirectory(FileSys.AppDataPath + $@"\WBot-Soft\BotGDX\Games\{_gameId}"); // Create the game directory
		}
		else
		{
			if (File.Exists(FileSys.AppDataPath + $@"\WBot-Soft\BotGDX\Games\{_gameId}\bg_img{_id}.jpg")) // If the image exist
			{
				File.Delete(FileSys.AppDataPath + $@"\WBot-Soft\BotGDX\Games\{_gameId}\bg_img{_id}.jpg");
			}

			await DownloadFileAsync(new Uri(_url), FileSys.AppDataPath + $@"\WBot-Soft\BotGDX\Games\{_gameId}\bg_img{_id}.jpg"); // Download the image
			return FileSys.AppDataPath + @$"\WBot-Soft\BotGDX\Games\{_gameId}\bg_img{_id}.jpg"; // Return the result
		}

		await DownloadFileAsync(new Uri(_url), FileSys.AppDataPath + $@"\WBot-Soft\BotGDX\Games\{_gameId}\bg_img{_id}.jpg"); // Download the image
		return FileSys.AppDataPath + @$"\WBot-Soft\BotGDX\Games\{_gameId}\bg_img{_id}.jpg"; // Return the path
	}

	private static async Task DownloadFileAsync(Uri uri, string filePath)
	{
		using var s = await new HttpClient().GetStreamAsync(uri);
		using var fs = new FileStream(filePath, FileMode.CreateNew);
		await s.CopyToAsync(fs);
	}
}
