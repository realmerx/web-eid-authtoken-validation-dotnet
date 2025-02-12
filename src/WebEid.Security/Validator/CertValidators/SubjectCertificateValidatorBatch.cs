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
namespace WebEid.Security.Validator.CertValidators
{
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    internal sealed class SubjectCertificateValidatorBatch
    {
        private readonly List<ISubjectCertificateValidator> validatorList;

        public static SubjectCertificateValidatorBatch CreateFrom(params ISubjectCertificateValidator[] validatorList) =>
            new SubjectCertificateValidatorBatch(new List<ISubjectCertificateValidator>(validatorList));

        public async Task ExecuteFor(X509Certificate2 subjectCertificate)
        {
            foreach (var validator in this.validatorList)
            {
                await validator.Validate(subjectCertificate);
            }
        }

        public SubjectCertificateValidatorBatch AddOptional(bool condition, ISubjectCertificateValidator optionalValidator)
        {
            if (condition)
            {
                this.validatorList.Add(optionalValidator);
            }
            return this;
        }

        private SubjectCertificateValidatorBatch(List<ISubjectCertificateValidator> validatorList) =>
            this.validatorList = validatorList;
    }
}
