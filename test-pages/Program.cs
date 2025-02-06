using System;
using System.Net.Mail;

public class Program
{
	public static void Main()
	{
		String[] testData = {
			// Valid email addresses.
			"ABCDEFGHIJKLMNOPQRSTUVWXYZ@uppercase.example",
			"abcdefghijklmnopqrstuvwxyz@lowercase.example",
			"0123456789@digits.example",
			"!#$%&'*+-/=?^_`{|}~@permitted.symbols.example",
			"9+three=OneDozen@mixed.example",
			"ZYXWVUTSRQPONMLKJIHGFEDCBA.ABCDEFGHIJKLMNOPQRSTUVWXYZ@example.com",
			"zyxwvutsrqponmlkjihgfedcba.abcdefghijklmnopqrstuvwxyz@example.org",
			"~}|{`_^?=/-+*'&%$#!9876543210.0123456789!#$%&'*+-/=?^_`{|}~@example.net",
			"UPPER.&.lower.+.123!@dot-atom.example",
			"?@1.example",
			"valid.address(comments are allowed but)@(SHOULD NOT be used around the \"@\" in the addr-spec)with-comments.example",
			"discouraged@example",
			"_@example",
			"valid_but_useless@undeliverable.invalid",
			"IPv4-literal@[192.168.1.2]",
			"coffee@[IPv6:2001:db8::cafe]",
			"\"Spaces are allowed in quoted-string.\"@example.com",
			"\"Commas, colons and at-signs are OK: @\"@example.org",
			"\" \"@single.space.example",
			"\"\\\"\"@single.quote.example",
			"\"The backslash character, \\\"\\\\\\\", must be quoted\"@complicated.example",
			// Valid email addresses that are potentially unsafe.
			"\"<script>alert('Gotcha!');</script>\"@script.example.net",
			"ring-the-bell@[non-standard-tag:ding\ading]",
			"\"\e[31;1;5mWARNING!\e[m\"@escape-sequences.example.net",
			// Invalid email addresses.
			".leadingDot@not.permitted.example",
			"no,commas@not.allowed.example",
			"not\"valid@example.com",
			"no\\\"escape@example.org",
		};
		foreach (String item in testData) {
			try {
				MailAddress address = new MailAddress(item);
				Console.WriteLine("Hello, " + address);
			} catch (FormatException ex) {
				Console.WriteLine("-- INVALID -- " + item + " -- " + ex.Message);
			}
		}
	}
}
