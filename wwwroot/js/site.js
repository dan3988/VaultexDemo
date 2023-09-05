// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class HttpError extends Error {
	get status() {
		return this.body.status;
	}

	get statusText() {
		return this.body.statusText;
	}

	/**
	 * @param {Response} body
	 */
	constructor(body) {
		super("Http request failed with status code " + body.status);
		this.body = body;
	}
}

/**
 * @param {"GET" | "POST" | "PUT" | "DELETE"} method
 * @param {string} url
 * @param {any} [body]
 * @returns
 */
async function rest(method, url, body) {
	const headers = {};
	if (body !== undefined) {
		body = JSON.stringify(body);
		headers["content-type"] = "application/json";
	}

	const response = await fetch(url, {
		method,
		body
	});

	if (!response.ok)
		throw new HttpError(response);

	return await response.json();
}

/**
 * @template {any} T
 * @param {string} url
 * @returns {Promise<T>}
 */
rest.get = function (url) {
	return rest("GET", url);
}

/**
 * @template {any} T
 * @param {string} url
 * @returns {Promise<T>}
 */
rest.delete = function (url) {
	return rest("DELETE", url);
}

/**
 * @template {any} T
 * @param {string} url
 * @param {any} body
 * @returns {Promise<T>}
 */
rest.post = function (url, body) {
	return rest("POST", url, body);
}

/**
 * @template {any} T
 * @param {string} url
 * @param {any} body
 * @returns {Promise<T>}
 */
rest.put = function (url, body) {
	return rest("PUT", url, body);
}
