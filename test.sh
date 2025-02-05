#!/bin/bash
trap 'echo "errexit on line ${LINENO} with exit code $?" >&2' ERR
set -Eeu

# TODO: The script should fail if any grep command has an exit code other than 0 or 1.

extract_test_email_addresses() {
    local -r type=$1
    grep --recursive --no-filename --fixed-strings "(${type})" test-pages \
        | sed --regexp-extended \
            -e 's~^\* <code>(.*)</code>.* (\('"${type}"'\))$~\1 \2~' \
        | sed -e 's/^  //' -e 's/ ('"${type}"')$//' \
        | sort
}

invalid() {
    extract_test_email_addresses INVALID
}

valid() {
    extract_test_email_addresses VALID
}

scraped() {
    ./scrape-from-page.sh | grep @ | sort
}

check_set_up() {
    local -r source=urls.txt
    local -r test_data=urls.txt.example2
    cmp --silent "${source}" "${test_data}" \
        || {
            local -r cmp_status=$?
            printf "\nExpected content of files to match:\n  %s\n  %s\n" \
                "${source}" "${test_data}" >&2
            if [ "${cmp_status}" -ne 1 ]; then
                cmp "${source}" "${test_data}"
            fi
            exit 1
        }
}

format_list() {
    local -r title=$1
    cat --number | awk "NR==1 {print\"\\n${title}\"} {print}"
}

run_test() {
    local diff_output
    diff_output=$(diff <(valid) <(scraped)) \
        || {
            local -r diff_status=$?
            if [ "${diff_status}" -ne 1 ]; then
                echo "diff failed." >&2
                exit "${diff_status}"
            fi
            grep '^<' <<<"${diff_output}" \
                | cut -c2- \
                | format_list 'Valid but not scraped.'
            grep '^>' <<<"${diff_output}" \
                | cut -c2- \
                | format_list 'Scraped but not valid.'
            invalid | format_list 'Invalid.'
            echo
            exit 1
        }
    echo All OK.
}

main() {
    check_set_up
    run_test
}

main
