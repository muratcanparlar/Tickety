-- Create table for Event
-- Create table for Category
CREATE TABLE category (
    id uuid NOT NULL PRIMARY KEY,
    name VARCHAR(200) NOT NULL,
    is_archived boolean NOT NULL DEFAULT false
);

-- Create table for Event
CREATE TABLE event (
    id uuid NOT NULL PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    description TEXT NOT NULL,
    location VARCHAR(200) NOT NULL,
    starts_at_utc timestamp(6) without time zone NOT NULL,
    ends_at_utc timestamp(6) without time zone NOT NULL,
    status int NOT NULL,
    category_id uuid NOT NULL,
    CONSTRAINT fk_event_category FOREIGN KEY(category_id) REFERENCES category(id)
);
