-- Create table for Event
CREATE TABLE event (
    id uuid NOT NULL PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    description TEXT NOT NULL,
    location VARCHAR(200) NOT NULL,
    starts_at_utc timestamp(6) without time zone NOT NULL,
    ends_at_utc timestamp(6) without time zone NOT NULL,
    status VARCHAR(200) NOT NULL
);