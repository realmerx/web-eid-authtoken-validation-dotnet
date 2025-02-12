﻿/*
 * Copyright © 2020-2023 Estonian Information System Authority
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
namespace WebEid.Security.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Thrown when the given certificate is not signed by a trusted CA.
    /// </summary>
    [Serializable]
    public class CertificateNotTrustedException : AuthTokenException
    {
        public CertificateNotTrustedException(X509Certificate2 certificate) :
            base($"Certificate {certificate.Subject} is not trusted")
        {
        }

        public CertificateNotTrustedException(X509Certificate2 certificate, string message) :
            base($"Certificate {certificate.Subject} is not trusted: {message}")
        {
        }

        public CertificateNotTrustedException(X509Certificate2 certificate, Exception innerException) :
            base($"Certificate {certificate.Subject} is not trusted", innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected CertificateNotTrustedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
