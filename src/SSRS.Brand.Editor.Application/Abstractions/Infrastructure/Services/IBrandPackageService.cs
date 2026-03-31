// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;

/// <summary>
/// The brand package service interface for serialization and deserialization of brand packages.
/// </summary>
public interface IBrandPackageService
{
	/// <summary>
	/// Reads a brand package from the specified ZIP file path.
	/// </summary>
	/// <param name="filePath">The path to the brand package ZIP file.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The deserialized brand package model.</returns>
	Task<BrandPackageModel> ReadAsync(string filePath, CancellationToken cancellationToken = default);

	/// <summary>
	/// Writes a brand package to the specified ZIP file path.
	/// </summary>
	/// <param name="filePath">The path to write the brand package ZIP file.</param>
	/// <param name="model">The brand package model to serialize.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	Task WriteAsync(string filePath, BrandPackageModel model, CancellationToken cancellationToken = default);
}
