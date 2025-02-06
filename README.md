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
