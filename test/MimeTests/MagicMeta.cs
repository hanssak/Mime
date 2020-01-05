﻿using HeyRed.Mime;

using Xunit;

namespace MimeTests
{
    public class MagicMeta
    {
        [Fact]
        public void CheckVersion() => Assert.Equal(530, Magic.Version);

        [Fact]
        public void GetFlags()
        {
            using var magic = new Magic(MagicOpenFlags.MAGIC_MIME_TYPE);

            Assert.Equal(MagicOpenFlags.MAGIC_MIME_TYPE, magic.GetFlags());
        }

        [Fact]
        public void SetFlags()
        {
            var flags = MagicOpenFlags.MAGIC_MIME_TYPE | MagicOpenFlags.MAGIC_MIME_ENCODING;

            using var magic = new Magic(MagicOpenFlags.MAGIC_NONE);
            magic.SetFlags(flags);

            Assert.Equal(flags, magic.GetFlags());
        }

        // TODO: Check invalid list?
        [Fact]
        public void ValidateDatabase()
        {
            using var magic = new Magic(MagicOpenFlags.MAGIC_NONE);

            Assert.True(magic.IsValidDatabase());
        }

        [Fact]
        public void GetParams()
        {
            using var magic = new Magic(MagicOpenFlags.MAGIC_NONE);
            int value = magic.GetParam(MagicParams.MAGIC_PARAM_NAME_MAX);

            Assert.Equal(30, value);
        }

        [Fact]
        public void SetParams()
        {
            int expected = 20;

            using var magic = new Magic(MagicOpenFlags.MAGIC_NONE);

            magic.SetParam(MagicParams.MAGIC_PARAM_NAME_MAX, expected);
            int value = magic.GetParam(MagicParams.MAGIC_PARAM_NAME_MAX);

            Assert.Equal(expected, value);
        }
    }
}
