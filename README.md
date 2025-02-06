# Web Email Harvest

Extract email addresses from a web page.

## Regex

Email address regext pattern taken from here:  
<https://stackoverflow.com/questions/201323/how-can-i-validate-an-email-address-using-a-regular-expression>

## Usage

Place urls to scan in a file called `urls.txt` then run `./scrape-from-page.sh`. Email addresses are output to terminal.

## Testing

1. Copy `urls.text.example2` to `urls.txt`.
2. Run `./test.sh`.

## Valid but potentially unsafe email addresses

1. Copy `urls.text.example3` to `urls.txt`.
2. Run `./scrape-from-page.sh`.
3. The bell should sound since one email address contains a BEL character.
4. The text `WARNING!` should flash since another email address contains ANSI escape sequences.
