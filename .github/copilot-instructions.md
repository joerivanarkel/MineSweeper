# Copilot instructions for this repo

These guidelines help Copilot and contributors keep UI code consistent and maintainable in this Blazor WebAssembly project.

## Always pair .razor with .razor.css

For every Razor component or page you create or edit, ensure there is a matching stylesheet with the same basename:

- Components and pages
  - `*.razor` ↔ `$(basename).razor.css`
- Examples:
  - `Components/GameBoard.razor` ↔ `Components/GameBoard.razor.css`
  - `Pages/MineSweeper.razor` ↔ `Pages/MineSweeper.razor.css`

Notes for Blazor CSS isolation:
- `*.razor.css` is automatically scoped to its component. Do not add `<link>` tags to include it.
- Keep selectors specific to this component. Avoid global tags like `body`, `html`, or global utility classes inside component CSS unless explicitly intended and justified.

## What goes where

- Component-specific styles → put in that component's `$(basename).razor.css`.
  - Examples: layout of the component’s root, child element styling, component-only states.
- Shared/reusable/generic styles → put in a global or shared stylesheet under `wwwroot/css/` (for example `wwwroot/css/app.css` or `wwwroot/css/utilities.css`).
  - Examples: color tokens, spacing scale, utility classes, button primitives, grid helpers, typography.

Import guidance:
- If you need shared styles to be globally available, add or update the `<link>` in `wwwroot/index.html` to include the shared CSS (app.css is already linked).
- If you want to reuse shared snippets but keep them scoped to a single component, you may use `@import` inside that component’s `.razor.css` to pull in a partial intended for isolation. Imported rules will be scoped to that component.
- Do NOT import truly global CSS files (like `app.css`) into a `.razor.css`; that would scope global utilities and defeat reuse.

## Styling rules

When generating or updating styles:
- In `.razor.css`: only component-specific rules. Prefer semantic class names in kebab-case (e.g., `.game-board`, `.preset-buttons`).
- In global/shared CSS: generic utilities, theme tokens, primitives. Reference with classes or rely on the global link in `index.html`.
- Avoid inline styles in `.razor`; add classes and put the CSS in the appropriate file instead.
- Use theme tokens from `wwwroot/css/app.css` when possible (CSS variables, colors, spacing).
- Keep hover/focus/active states accessible (contrast ≥ WCAG AA; visible focus ring).
- Do not leak global styles from a component. Move shared rules to a shared stylesheet.

## File moves/renames

- If a `*.razor` file is moved or renamed, apply the same change to its `*.razor.css` peer.
- Keep basenames in sync so Blazor continues to apply CSS isolation correctly and the Explorer nesting remains intact.

## Do and don’t

Do
- Create/update `$(basename).razor.css` whenever you create/update `*.razor`.
- Keep component styles scoped to the component; use the component’s wrapper/root classes.
- Place shared utilities and theme tokens in `wwwroot/css/app.css` (or another shared file) and reference them as needed.

Don’t
- Add inline styles to markup unless temporary and explicitly justified.
- Put shared/global styles in a component’s `.razor.css`.
- Leave a component without a matching stylesheet if it renders UI.

## Acceptance checklist for PRs & suggestions

- [ ] Every changed/added `*.razor` has a matching `$(basename).razor.css` (or a conscious decision noted in the PR).
- [ ] Component-specific rules live in that component’s `.razor.css`; shared/generic rules live in a shared stylesheet under `wwwroot/css/`.
- [ ] No global leakage from component CSS; global styles live in `wwwroot/css/app.css` (or a shared file), linked in `index.html`.
- [ ] No unnecessary inline styles; classes are used with CSS in the appropriate stylesheet.
- [ ] Visual states (hover/focus/active) are implemented where relevant and accessible.

---

Context: This project nests `$(basename).razor.css` under `*.razor` in VS Code (see `.vscode/settings.json`) so keeping basenames aligned improves discoverability.
