// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.IO;

namespace SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Providers;

/// <summary>
/// This interface defines a contract for directory provider.
/// </summary>
/// <remarks>
/// Serves as an abstraction for the <see cref="Directory"/> operations.
/// </remarks>
public interface IDirectoryProvider
{
	/// <inheritdoc cref="Directory.CreateDirectory(string)"/>
	void CreateDirectory(string path);

	/// <inheritdoc cref="Directory.Delete(string, bool)"/>
	void Delete(string path, bool recursive = false);

	/// <inheritdoc cref="Directory.Exists(string)"/>
	bool Exists(string path);

	/// <inheritdoc cref="Directory.GetDirectories(string, string, SearchOption)"/>
	string[] GetDirectories(string path, string searchPattern = "*.*", SearchOption searchOption = SearchOption.TopDirectoryOnly);

	/// <inheritdoc cref="Directory.GetFiles(string, string, SearchOption)"/>
	string[] GetFiles(string path, string searchPattern = "*.*", SearchOption searchOption = SearchOption.TopDirectoryOnly);

	/// <inheritdoc cref="Directory.Move(string, string)"/>
	void Move(string sourceDirName, string destDirName);

	/// <inheritdoc cref="Directory.GetLogicalDrives()"/>
	string[] GetLogicalDrives();
}
